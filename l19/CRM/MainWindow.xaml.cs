using System;
using System.Windows;
using CRM.ViewModels;

namespace CRM
{
    public partial class MainWindow : Window
    {
        private readonly CRMViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new CRMViewModel();
            ShowLogin();
        }

        private async void ShowLogin()
        {
            var loginWindow = new LoginWindow(_viewModel);
            if (loginWindow.ShowDialog() != true)
            {
                Close();
                return;
            }

            DataContext = _viewModel;
            await _viewModel.LoadDataAsync();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            _viewModel.Shutdown();
            base.OnClosed(e);
        }
    }
}