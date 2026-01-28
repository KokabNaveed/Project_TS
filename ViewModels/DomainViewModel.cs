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

        public DomainSubscription Domain { get; set; }

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
        }
    }
}
