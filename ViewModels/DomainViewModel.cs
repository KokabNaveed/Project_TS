using Project.Commands;
using Project.Models;
using Project.Services;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class DomainViewModel : BaseViewModel
    {
        private readonly DomainService _domainService;

        private DomainSubscription _domainSubscription;
        public DomainSubscription Domain {
            get
            {
                return _domainSubscription;
            }

            set
            {
                _domainSubscription = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateCommand { get; }

        public DomainViewModel()
        {
            _domainService = new DomainService();
            Domain = new DomainSubscription();
            CreateCommand = new RelayCommand(o=> CreateDomain());
        }

        private void CreateDomain()
        {
            string DomainName = Domain.DomainName;
            string DomainRegistrar = Domain.Registrar;
            string DNS1 = Domain.NameServer1;
            string DNS2 = Domain.NameServer2;
            decimal amount = Domain.Amount;


            if (string.IsNullOrWhiteSpace(Domain.DomainName))
            {
                MessageBox.Show("Domain name is required");
                return;
            }

            _domainService.AddDomain(Domain);

            MessageBox.Show("Domain saved successfully!");

            Domain = new DomainSubscription();

        }

    }
}
