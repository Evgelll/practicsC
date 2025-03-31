using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace CRMApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> Clients { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Clients = new ObservableCollection<Client>();
            ClientsListView.DataContext = this;

            LoadClients(); 
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            if (clientForm.ShowDialog() == true)
            {
                Clients.Add(clientForm.Client);
            }
        }

        private void EditClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsListView.SelectedItem is Client selectedClient)
            {
                ClientForm clientForm = new ClientForm(selectedClient);
                if (clientForm.ShowDialog() == true)
                {
                    selectedClient.FullName = clientForm.Client.FullName;
                    selectedClient.Contact = clientForm.Client.Contact;
                    selectedClient.InteractionHistory = clientForm.Client.InteractionHistory;
                    ClientsListView.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования.");
            }
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsListView.SelectedItem is Client selectedClient)
            {
                Clients.Remove(selectedClient);
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.");
            }
        }

        private void SaveClients()
        {
            using (StreamWriter writer = new StreamWriter("clients.txt"))
            {
                foreach (var client in Clients)
                {
                    writer.WriteLine($"{client.FullName};{client.Contact};{client.InteractionHistory}");
                }
            }
        }

        private void LoadClients()
        {
            if (File.Exists("clients.txt"))
            {
                using (StreamReader reader = new StreamReader("clients.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(';');
                        if (parts.Length == 3)
                        {
                            Clients.Add(new Client
                            {
                                FullName = parts[0],
                                Contact = parts[1],
                                InteractionHistory = parts[2]
                            });
                        }
                    }
                }
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            SaveClients(); 
            base.OnClosing(e);
        }

        private void ClientsListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}