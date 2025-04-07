using System.Windows;
using System.Windows.Controls;
using CRM.Models;
using CRM.ViewModels;

namespace CRM
{
    public partial class RegisterWindow : Window
    {
        private readonly CRMViewModel _viewModel;
        public string Username { get; set; }

        public RegisterWindow(CRMViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = this;
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordBox.Password;
            var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            UserRole role = selectedRole == "Admin" ? UserRole.Admin : UserRole.Manager;

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (await _viewModel.RegisterAsync(Username, password, role)) // Используем RegisterAsync
            {
                MessageBox.Show("Пользователь успешно зарегистрирован", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}