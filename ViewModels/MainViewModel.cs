using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Project.Commands;
using Project.Views;

namespace Project.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
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
            ShowEmailCommand = new RelayCommand(o => CurrentView = new EmailView());
            ShowDomainCommand = new RelayCommand(o => CurrentView = new DomainView());
            ShowSoftwareCommand = new RelayCommand(o => CurrentView = new SoftwareView());

            CurrentView = new EmailView(); // default
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
