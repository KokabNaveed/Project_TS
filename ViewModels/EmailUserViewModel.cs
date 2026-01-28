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

        public EmailUser User { get; set; }

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
        }
    }
}
