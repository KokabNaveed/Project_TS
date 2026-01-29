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

        public ICommand SubmitCommand { get; }

        public DomainViewModel()
        {
            _domainService = new DomainService();
            Domain = new DomainSubscription();
            SubmitCommand = new RelayCommand(o=>Submit());
        }

        private void Submit()
        {
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
