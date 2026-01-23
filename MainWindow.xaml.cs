using System.Linq;
using System.Windows;
using Project.Services;

namespace Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadAllDataByDefault();
        }

        // Load all users/data when the window opens
        private void LoadAllDataByDefault()
        {
            using (var db = new AppDbContext())
            {
                // Load Email users as default
                var users = db.EmailUsers
                              .Select(u => new
                              {
                                  u.Id,
                                  u.FirstName,
                                  u.LastName,
                                  u.EmailAddress,
                                  u.Company,
                                  u.StorageGB
                                  // Do NOT include Password
                              })
                              .ToList();

                dataGrid.ItemsSource = users;
            }

            dataGrid.Visibility = Visibility.Visible;
        }

        private void EmailMenu_Click(object sender, RoutedEventArgs e)
        {
            Email emailUser = new Email();
            emailUser.Show();
            this.Close();
        }

        private void DomainMenu_Click(object sender, RoutedEventArgs e)
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

        // Show Software Data
        private void SoftwareData_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                var softwares = db.Softwares
                                  .Select(s => new
                                  {
                                      s.Id,
                                      s.SoftwareName,
                                      s.PlanType,
                                      s.Email,
                                      s.Amount,
                                      s.SubscribedDate,
                                      s.RenewalDate
                                  })
                                  .ToList();

                dataGrid.ItemsSource = softwares;
            }

            dataGrid.Visibility = Visibility.Visible;
        }

        // Show Email Data
        private void EmailData_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                var users = db.EmailUsers
                              .Select(u => new
                              {
                                  u.Id,
                                  u.FirstName,
                                  u.LastName,
                                  u.EmailAddress,
                                  u.Company,
                                  u.StorageGB
                                  // Password excluded
                              })
                              .ToList();

                dataGrid.ItemsSource = users;
            }

            dataGrid.Visibility = Visibility.Visible;
        }

        // Show Domain Data
        private void DomainData_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                var domains = db.Domains
                                .Select(d => new
                                {
                                    d.Id,
                                    d.DomainName,
                                    d.RegisteredDate,
                                    d.RenewalDate,
                                    d.Registrar,
                                    d.Amount,
                                    d.NameServer1,
                                    d.NameServer2,
                                    d.AutoRenew
                                })
                                .ToList();

                dataGrid.ItemsSource = domains;
            }

            dataGrid.Visibility = Visibility.Visible;
        }
    }
}
