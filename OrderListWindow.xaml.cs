using MAS_projekt.DAL;
using MAS_projekt.Models.Orders;
using MAS_projekt.Models.People;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MAS_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        private readonly OrderService _orderService;
        private readonly PersonService _personService;
        private readonly ObservableCollection<Order> allOrders;
        private ObservableCollection<Order> filteredOrders;
        private readonly ObservableCollection<Client> allClients;

        public OrderListWindow()
        {
            InitializeComponent();
            _orderService = new OrderService();
            _personService = new PersonService();
            allOrders = _orderService.GetOrdersInProgressOrCreated();
            allClients = _personService.GetClients();
            filteredOrders = allOrders;
            OrderDataGrid.ItemsSource = filteredOrders;
            ClientComboBox.ItemsSource = allClients;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();
            if (ClientComboBox.SelectedItem == null)
            {
                filteredOrders = _orderService.GetOrdersInProgressOrCreatedFilteredByNumber(text);
            } else
            {
                var client = (Client)ClientComboBox.SelectedItem;
                filteredOrders = _orderService.GetOrdersOfClientFilteredByNumber(client, text);
            }
            OrderDataGrid.ItemsSource = null;
            OrderDataGrid.ItemsSource = filteredOrders;
        }

        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selectedClient = (Client)comboBox.SelectedItem;
            var text = FilterTextBox.Text.Trim();
            filteredOrders = _orderService.GetOrdersOfClientFilteredByNumber(selectedClient, text);
            OrderDataGrid.ItemsSource = null;
            OrderDataGrid.ItemsSource = filteredOrders;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrderDataGrid.SelectedItem == null)
            {
                return;
            }
            var selectedOrder = (Order)OrderDataGrid.SelectedItem;
            new OrderDetailsWindow(selectedOrder).Show();
            this.Close();
        }
    }
}
