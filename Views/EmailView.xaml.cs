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
            DataContext = new EmailUserViewModel();
        }

        // PasswordBox exception (MVVM-acceptable)
        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is EmailUserViewModel vm)
            {
                vm.User.Password = TxtPassword.Password;
            }
        }
    }
}
