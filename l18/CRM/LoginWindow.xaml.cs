using System.Windows;
using System.Windows.Controls;
using CRM.ViewModels;

namespace CRM
{
    public partial class LoginWindow : Window
    {
        private readonly CRMViewModel _viewModel;
        public string Username { get; set; }

        public LoginWindow(CRMViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = this;
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordBox.Password;
            if (await _viewModel.LoginAsync(Username, password))
            {
                DialogResult = true;
                Close(); 
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow(_viewModel) { Owner = this };
            registerWindow.ShowDialog();
        }
    }
}