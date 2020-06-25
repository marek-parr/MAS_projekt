using MAS_projekt.DAL;
using MAS_projekt.Models.Orders;
using MAS_projekt.Models.People;
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
        private ICollection<Order> allOrders;
        private ICollection<Order> filteredOrders;
        private ICollection<Client> allClients;

        public OrderListWindow()
        {
            InitializeComponent();
            _dbService = new DbService();
            allOrders = _dbService.GetOrders();
            allClients = _dbService.GetClients();
            filteredOrders = allOrders;
            OrderDataGrid.ItemsSource = filteredOrders;
            ClientComboBox.ItemsSource = allClients;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            filteredOrders = _dbService.GetOrdersFilteredByNumber(textBox.Text.Trim());
            OrderDataGrid.ItemsSource = null;
            OrderDataGrid.ItemsSource = filteredOrders;
        }

        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var selectedClient = (Client)comboBox.SelectedItem;
            filteredOrders = _dbService.GetOrdersOfClient(selectedClient);
        }
    }
}
