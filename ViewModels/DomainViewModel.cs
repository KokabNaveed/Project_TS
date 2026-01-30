using Project.Commands;
using Project.Models;
using Project.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class DomainViewModel : BaseViewModel
    {
        private readonly DomainService _domainService;

        private DomainSubscription _domain;
        public DomainSubscription Domain
        {
            get => _domain;
            set { _domain = value; OnPropertyChanged(); }
        }

        public ObservableCollection<DomainSubscription> DomainList { get; } = new();

        public ICommand SubmitCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public DomainViewModel()
        {
            _domainService = new DomainService();

            Domain = new DomainSubscription();
            LoadDomains();

            SubmitCommand = new RelayCommand(_ => Submit());
            EditCommand = new RelayCommand(d => LoadForEdit(d as DomainSubscription));
            DeleteCommand = new RelayCommand(d => Delete(d as DomainSubscription));
        }

        private void LoadDomains()
        {
            DomainList.Clear();
            foreach (var d in _domainService.GetAll())
                DomainList.Add(d);
        }

        private void LoadForEdit(DomainSubscription domain)
        {
            if (domain == null) return;

            Domain = new DomainSubscription
            {
                Id = domain.Id,
                DomainName = domain.DomainName,
                Registrar = domain.Registrar,
                NameServer1 = domain.NameServer1,
                NameServer2 = domain.NameServer2,
                Amount = domain.Amount,
                RegisteredDate = domain.RegisteredDate,
                RenewalDate = domain.RenewalDate,
                AutoRenew = domain.AutoRenew
            };
        }

        private void Submit()
        {
            if (string.IsNullOrWhiteSpace(Domain.DomainName))
            {
                MessageBox.Show("Domain name is required");
                return;
            }

            if (Domain.Id > 0)
            {
                _domainService.UpdateDomain(Domain);
                MessageBox.Show("Domain updated successfully");
            }
            else
            {
                _domainService.AddDomain(Domain);
                MessageBox.Show("Domain added successfully");
            }

            Domain = new DomainSubscription();
            LoadDomains();
        }

        private void Delete(DomainSubscription domain)
        {
            if (domain == null) return;

            var result = MessageBox.Show("Delete this domain?",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _domainService.RemoveDomain(domain);
                LoadDomains();
            }
        }
    }
}
