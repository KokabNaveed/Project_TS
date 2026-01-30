using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project.Commands;
using System.Windows.Controls;
using System.Windows.Input;
using Project.Views;

namespace Project.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        public string Email { get; set; }
        public string ErrorMessage { get; set; }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(o=>Login(o));
        }

        private void Login(object param)
        {
            if (param is not PasswordBox pwdBox)
            {
                ErrorMessage = "Password is required";
                OnPropertyChanged(nameof(ErrorMessage));
                return;
            }

            string pwd = pwdBox.Password;

            if (Email == "admin" && pwd == "admin")
            {
                new MainWindow().Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                ErrorMessage = "Invalid credentials";
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
    }
}
