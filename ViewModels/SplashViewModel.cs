using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Project.Views;

namespace Project.ViewModels
{
    public class SplashViewModel
    {
        public SplashViewModel()
        {
            Load();
        }

        private async void Load()
        {
            await Task.Delay(3000);
            new LoginView().Show();
            Application.Current.Windows[0].Close();
        }
    }
}
