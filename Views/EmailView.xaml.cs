using System.Windows;
using System.Windows.Controls;
using Project.ViewModels;

namespace Project.Views
{
    /// <summary>
    /// Interaction logic for EmailView.xaml
    /// </summary>
    public partial class EmailView : UserControl
    {
        public EmailView()
        {
            InitializeComponent();
            var vm = new EmailUserViewModel();

            DataContext = vm;



            // Subscribe to event to clear password
            vm.ClearPasswordRequested += () =>
            {
                TxtPassword.Password = string.Empty;
            };
        }

        // PasswordBox exception (MVVM-acceptable)
        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is EmailUserViewModel vm)
            {
                vm.User.Password = TxtPassword.Password;

                // Toggle placeholder visibility
                PasswordPlaceholder.Visibility = string.IsNullOrEmpty(TxtPassword.Password)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }
    }
}
