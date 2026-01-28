using Project.Commands;
using Project.Models;
using Project.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class SoftwareViewModel : BaseViewModel
    {
        private readonly SoftwareService _softwareService;

        public SoftwareSubscription Software { get; set; }

        public ObservableCollection<string> PlanTypes { get; }
        public ObservableCollection<string> Categories { get; }

        public ICommand SubmitCommand { get; }

        public SoftwareViewModel()
        {
            _softwareService = new SoftwareService();

            Software = new SoftwareSubscription();

            PlanTypes = new ObservableCollection<string>
            {
                "Free", "Monthly", "Yearly"
            };

            Categories = new ObservableCollection<string>
            {
                "Software", "Accounting", "Enterprise"
            };

            SubmitCommand = new RelayCommand(o => Submit());
        }

        private void Submit()
        {
            if (string.IsNullOrWhiteSpace(Software.SoftwareName))
            {
                MessageBox.Show("Software name is required");
                return;
            }

            _softwareService.AddSoftwareSubscription(Software);

            MessageBox.Show("Software subscription saved successfully!");
        }
    }
}
