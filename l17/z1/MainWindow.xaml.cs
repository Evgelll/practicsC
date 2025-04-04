using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace z1;

public partial class MainWindow : Window
{
    public ObservableCollection<ClientModel> Clients { get; set; }

    public CRMViewModel ViewModel { get; set; }

    private UserService _userService;

    public MainWindow()
    {
        InitializeComponent();
        Clients = new ObservableCollection<ClientModel>();
        ClientsListView.DataContext = this;
        ViewModel = new CRMViewModel();
        DataContext = ViewModel;
        _userService = new UserService();


        var loginForm = new LoginForm(_userService);
        loginForm.ShowDialog();


        LoadClients();
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Control)
        {
            switch (e.Key)
            {
                case Key.N:
                    AddClientCommand(null, null);
                    break;
                case Key.E:
                    EditClientCommand(null, null);
                    break;
                case Key.D:
                    DeleteClientCommand(null, null);
                    break;
            }
        }
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        MenuItem menuItem = (MenuItem)sender;
        MessageBox.Show(menuItem.Header.ToString());
    }

    private void AddClientCommand(object sender, RoutedEventArgs e)
    {
        ClientForm clientForm = new ClientForm();
        if (clientForm.ShowDialog() == true)
        {
            Clients.Add(clientForm.Client);
        }
    }

    private void EditClientCommand(object sender, RoutedEventArgs e)
    {
        if (ClientsListView.SelectedItem is ClientModel selectedClient)
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

    private void DeleteClientCommand(object sender, RoutedEventArgs e)
    {
        if (ClientsListView.SelectedItem is ClientModel selectedClient)
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
        using (StreamWriter writer = new StreamWriter("crm_data.json"))
        {
            foreach (var client in Clients)
            {
                writer.WriteLine($"{client.FullName};{client.Contact};{client.InteractionHistory};{client.ClientType}");
            }
        }
    }
    

    private async void LoadClients()
    {
        ViewModel.LoadClientsAsync();

        if (File.Exists("crm_data.json"))
        {
            using (StreamReader reader = new StreamReader("crm_data.json"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 4)
                    {
                        Clients.Add(new ClientModel
                        {
                            FullName = parts[0],
                            Contact = parts[1],
                            InteractionHistory = parts[2],
                            ClientType = parts[3]
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