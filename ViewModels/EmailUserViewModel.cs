using Project.Commands;
using Project.Models;
using Project.Services;
using System;
using System.Collections.ObjectModel;
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

        public ObservableCollection<EmailUser> EmailList { get; set; } = new();

        public event Action? ClearPasswordRequested;

        public ICommand SubmitCommand { get; } // Use single command for Add/Edit
        public ICommand DeleteUserCommand { get; }
        public ICommand EditUserCommand { get; }

        public EmailUserViewModel()
        {
            _service = new EmailUserService();
            User = new EmailUser();

            SubmitCommand = new RelayCommand(o => SubmitUser());
            DeleteUserCommand = new RelayCommand(o => DeleteUser(o as EmailUser));
            EditUserCommand = new RelayCommand(o => LoadUserForEdit(o as EmailUser));

            LoadEmails();
        }

        private void LoadEmails()
        {
            EmailList.Clear();
            foreach (var e in _service.GetAll())
                EmailList.Add(e);
        }

        private void LoadUserForEdit(EmailUser user)
        {
            if (user == null) return;

            User.Id = user.Id;
            User.FirstName = user.FirstName;
            User.LastName = user.LastName;
            User.EmailAddress = user.EmailAddress;
            User.Company = user.Company;
            User.Password = user.Password;
            User.StorageGB = user.StorageGB;

            OnPropertyChanged(nameof(User));
        }


        private void SubmitUser()
        {
            if (User.Id > 0)
            {
                _service.UpdateUser(User);

                // Update ObservableCollection
                var existing = EmailList.FirstOrDefault(u => u.Id == User.Id);
                if (existing != null)
                {
                    existing.FirstName = User.FirstName;
                    existing.LastName = User.LastName;
                    existing.EmailAddress = User.EmailAddress;
                    existing.Company = User.Company;
                    existing.StorageGB = User.StorageGB;
                    existing.Password = User.Password;
                }
            }
            else
            {
                _service.AddUser(User);
                EmailList.Add(User); // Add new user to collection
            }

            User = new EmailUser();
            ClearPasswordRequested?.Invoke();
            LoadEmails();
        }


        private void DeleteUser(EmailUser user)
        {
            if (user == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete {user.EmailAddress}?",
                                         "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _service.RemoveUser(user);
                MessageBox.Show("User deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                User = new EmailUser();
                ClearPasswordRequested?.Invoke();

                LoadEmails();
            }
        }
    }
}
