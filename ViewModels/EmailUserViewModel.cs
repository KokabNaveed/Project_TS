using Project.Commands;
using Project.Models;
using Project.Services;
using System;
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
        public ICommand DeleteUserCommand { get; }
        public ICommand EditUserCommand { get; }

        public EmailUserViewModel()
        {
            _service = new EmailUserService();
            User = new EmailUser();

            CreateUserCommand = new RelayCommand(o => CreateUser());
            DeleteUserCommand = new RelayCommand(o => DeleteUser(o as EmailUser));
            EditUserCommand = new RelayCommand(o => EditUser(o as EmailUser));
        }

        private void CreateUser()
        {
            if (string.IsNullOrWhiteSpace(User.EmailAddress))
            {
                MessageBox.Show("Email is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_service.EmailExists(User.EmailAddress))
            {
                MessageBox.Show("Email already exists", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _service.AddUser(User);
            MessageBox.Show("User created successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            User = new EmailUser();
            ClearPasswordRequested?.Invoke();
        }

        private void EditUser(EmailUser user)
        {
            if (user == null)
            {
                MessageBox.Show("No user selected to edit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(user.EmailAddress))
            {
                MessageBox.Show("Email cannot be empty", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Optional: Check if email is changing to one that already exists
            if (_service.EmailExists(user.EmailAddress) && user.Id != _service.GetUserIdByEmail(user.EmailAddress))
            {
                MessageBox.Show("Another user with this email already exists", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _service.UpdateUser(user);
            MessageBox.Show("User updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Refresh current user
            User = new EmailUser();
            ClearPasswordRequested?.Invoke();
        }

        private void DeleteUser(EmailUser user)
        {
            if (user == null)
            {
                MessageBox.Show("No user selected to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete {user.EmailAddress}?", "Confirm Delete",
                                         MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _service.RemoveUser(user);
                MessageBox.Show("User deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                User = new EmailUser();
                ClearPasswordRequested?.Invoke();
            }
        }
    }
}
