using System.Windows;
using Project.Services;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EmailMenu_Click(object sender, RoutedEventArgs e)
        {
            Email emailUser = new Email();
            emailUser.Show();
            this.Close();

        }

        private void DomainMenu_Click(Object sender, RoutedEventArgs e)
        {
            Domain domainUser = new Domain();
            domainUser.Show();
            this.Close();
        }

        private void SoftwareMenu_Click(object sender, RoutedEventArgs e)
        {
            Software softwareUser = new Software();
            softwareUser.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}