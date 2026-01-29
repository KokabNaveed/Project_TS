using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Project.Commands;
using Project.Views;

namespace Project.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowEmailCommand { get; }
        public ICommand ShowDomainCommand { get; }
        public ICommand ShowSoftwareCommand { get; }

        public MainViewModel()
        {
            ShowEmailCommand = new RelayCommand(o=>EmailCommand());
            ShowDomainCommand = new RelayCommand(o => DomainCommand());
            ShowSoftwareCommand = new RelayCommand(o =>SoftwareCommand());

            CurrentView = new EmailView(); // default
        }

        private void EmailCommand()
        {
            CurrentView = new EmailView();
        }

        private void DomainCommand()
        {
            CurrentView = new DomainView();
        }

        private void SoftwareCommand() 
        { 
            CurrentView = new SoftwareView();
        }

    }
}
