using Project.Commands;
using Project.Models;
using Project.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class SoftwareViewModel : BaseViewModel
    {
        private readonly SoftwareService _softwareService;

        public ObservableCollection<SoftwareSubscription> SoftwareList { get; set; } = new();

        private SoftwareSubscription _software;
        public SoftwareSubscription Software
        {
            get => _software;
            set
            {
                _software = value;
                OnPropertyChanged();
            }
        }

        private SoftwareSubscription _selectedSoftware;
        public SoftwareSubscription SelectedSoftware
        {
            get => _selectedSoftware;
            set
            {
                _selectedSoftware = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> PlanTypes { get; }
        public ObservableCollection<string> Categories { get; }

        public ICommand SubmitCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public SoftwareViewModel()
        {
            _softwareService = new SoftwareService();

            PlanTypes = new ObservableCollection<string>
            {
                "Free", "Monthly", "Yearly"
            };

            Categories = new ObservableCollection<string>
            {
                "Software", "Accounting", "Enterprise"
            };

            Software = new SoftwareSubscription
            {
                SubscribedDate = DateTime.Now
            };

            SubmitCommand = new RelayCommand(_ => Submit());
            EditCommand = new RelayCommand(o => LoadForEdit(o as SoftwareSubscription));
            DeleteCommand = new RelayCommand(o => Delete(o as SoftwareSubscription));

            LoadSoftwares();
        }

        private void LoadSoftwares()
        {
            SoftwareList.Clear();
            foreach (var s in _softwareService.GetAll())
                SoftwareList.Add(s);
        }

        private void LoadForEdit(SoftwareSubscription software)
        {
            if (software == null) return;

            Software = new SoftwareSubscription
            {
                Id = software.Id,
                SoftwareName = software.SoftwareName,
                PlanType = software.PlanType,
                Category = software.Category,
                Amount = software.Amount,
                Email = software.Email,
                RenewalDate = software.RenewalDate,
                SubscribedDate = software.SubscribedDate
            };
        }

        private void Submit()
        {
            if (string.IsNullOrWhiteSpace(Software.SoftwareName))
            {
                MessageBox.Show("Software name is required");
                return;
            }

            if (Software.Id > 0)
            {
                _softwareService.UpdateSoftwareSubscription(Software);
                MessageBox.Show("Software updated successfully!");
            }
            else
            {
                _softwareService.AddSoftwareSubscription(Software);
                MessageBox.Show("Software added successfully!");
            }

            Software = new SoftwareSubscription
            {
                SubscribedDate = DateTime.Now
            };

            LoadSoftwares();
        }

        private void Delete(SoftwareSubscription software)
        {
            if (software == null) return;

            var result = MessageBox.Show(
                $"Delete {software.SoftwareName}?",
                "Confirm",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _softwareService.RemoveSoftwareSubscription(software);
                LoadSoftwares();
            }
        }
    }
}
