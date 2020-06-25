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
        private DbService _dbService;
        private readonly ObservableCollection<Order> allOrders;
        private ObservableCollection<Order> filteredOrders;
        private readonly ObservableCollection<Client> allClients;

        public OrderListWindow()
        {
            InitializeComponent();
            _dbService = new DbService();
            allOrders = _dbService.GetOrdersInProgressOrCreated();
            allClients = _dbService.GetClients();
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
                filteredOrders = _dbService.GetOrdersFilteredByNumber(text);
            } else
            {
                var client = (Client)ClientComboBox.SelectedItem;
                filteredOrders = _dbService.GetOrdersOfClientFilteredByNumber(client, text);
            }
            OrderDataGrid.ItemsSource = null;
            OrderDataGrid.ItemsSource = filteredOrders;
        }

        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selectedClient = (Client)comboBox.SelectedItem;
            var text = FilterTextBox.Text.Trim();
            filteredOrders = _dbService.GetOrdersOfClientFilteredByNumber(selectedClient, text);
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
