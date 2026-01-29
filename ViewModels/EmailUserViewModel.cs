using Project.Commands;
using Project.Models;
using Project.Services;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModels
{
    public class EmailUserViewModel : BaseViewModel
    {
        private readonly EmailUserService _service;

        private EmailUser _user;
        public EmailUser User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();   
            }
        }

        public event Action? ClearPasswordRequested;


        public ICommand CreateUserCommand { get; }

        public EmailUserViewModel()
        {
            _service = new EmailUserService();
            User = new EmailUser();

            CreateUserCommand = new RelayCommand(o => CreateUser());
        }

        private void CreateUser()
        {
            if (string.IsNullOrWhiteSpace(User.EmailAddress))
            {
                MessageBox.Show("Email is required");
                return;
            }

            if (_service.EmailExists(User.EmailAddress))
            {
                MessageBox.Show("Email already exists");
                return;
            }

            _service.AddUser(User);
            MessageBox.Show("User created successfully");

            User = new EmailUser();

            OnPropertyChanged(nameof(User));

            // Trigger password clear in the view
            ClearPasswordRequested?.Invoke();
        }
    }
}
