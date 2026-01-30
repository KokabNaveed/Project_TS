using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Project.Commands;
using Project.Models;
using Project.Services;
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

        public ICommand ShowHomeCommand { get; }
        public ICommand ShowEmailCommand { get; }
        public ICommand ShowDomainCommand { get; }
        public ICommand ShowSoftwareCommand { get; }

        public ICommand ShowEmailListCommand { get; }
        public ICommand ShowDomainListCommand { get; }
        public ICommand ShowSoftwareListCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainViewModel()
        {
            ShowEmailCommand = new RelayCommand(o => EmailCommand());
            ShowDomainCommand = new RelayCommand(o => DomainCommand());
            ShowSoftwareCommand = new RelayCommand(o => SoftwareCommand());
            ShowSoftwareListCommand = new RelayCommand(o => ShowSoftware());
            ShowHomeCommand = new RelayCommand(o => HomeCommand());
            LogoutCommand = new RelayCommand(o => ExitCommand());

            CurrentView = new HomeView();
        }



        private void HomeCommand()
        {
            CurrentView = new HomeView();
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
        private void ShowSoftware()
        {
            CurrentView = new ListViewControl();

        }
        private void ExitCommand()
        {

            Application.Current.Shutdown(); // This will close the entire WPF app
        }
          
    }
}
