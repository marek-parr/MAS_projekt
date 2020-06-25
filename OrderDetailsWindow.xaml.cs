using MAS_projekt.DAL;
using MAS_projekt.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MAS_projekt
{
    /// <summary>
    /// Interaction logic for OrderDetailsWindow.xaml
    /// </summary>
    public partial class OrderDetailsWindow : Window
    {
        private readonly OrderService _dbService;
        public string WindowTitle { get; }
        public Order Order { get; }

        public OrderDetailsWindow(Order order)
        {
            InitializeComponent();
            _dbService = new OrderService();
            this.Order = order;
            DataContext = this;
            WindowTitle = $"Zamówienie {order.OrderNumber}";
            ItemsDataGrid.ItemsSource = Order.Items;
            if (!order.State.Equals(OrderState.IN_PROGRESS)) {
                RejectButton.Visibility = Visibility.Hidden;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new OrderListWindow().Show();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var nextState = Order.State + 1;
            var result = MessageBox.Show($"Czy na pewno chcesz przejść do następnego etapu w zamówieniu {Order.OrderNumber}?\n" +
                $"Spowoduje to zmianę statusu z \"{Order.StateString}\" na \"{nextState.GetOrderStateDisplayName()}\".", "Przejdź do następnego etapu", MessageBoxButton.YesNo);
            if (result.Equals(MessageBoxResult.Yes))
            {
                _dbService.ProceedToNextOrderState(Order.Id);
                this.Close();
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Czy na pewno chcesz oznaczyć zamówienie {Order.OrderNumber} jako odrzucone?", "Oznacz jako odrzucone", MessageBoxButton.YesNo);
            if (result.Equals(MessageBoxResult.Yes))
            {
                _dbService.RejectOrder(Order.Id);
                this.Close();
            }
        }
    }
}
