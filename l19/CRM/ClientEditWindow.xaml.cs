using System.Windows;
using System.Collections.ObjectModel;
using CRM.Models;

namespace CRM
{
    public partial class ClientEditWindow : Window
    {
        public ObservableCollection<string> ClientTypes { get; }

        public ClientEditWindow(ClientModel client, ObservableCollection<string> clientTypes)
        {
            InitializeComponent();
            DataContext = client;
            ClientTypes = clientTypes;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}