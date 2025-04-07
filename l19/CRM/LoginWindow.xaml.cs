using System.Windows;
using System.Windows.Controls;
using CRM.ViewModels;
using System.Diagnostics;

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
            try
            {
                string password = PasswordBox.Password;
                Debug.WriteLine($"Попытка входа: Username={Username}, Password={password}");
                if (await _viewModel.LoginAsync(Username, password))
                {
                    Debug.WriteLine("Успешный вход");
                    DialogResult = true;
                    Close();
                }
                else
                {
                    Debug.WriteLine("Неудачный вход");
                    MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при входе: {ex.Message}");
                MessageBox.Show($"Ошибка при входе: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow(_viewModel) { Owner = this };
            registerWindow.ShowDialog();
        }
    }
}