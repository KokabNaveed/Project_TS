using System.Linq;
using System.Windows;
using Project.ViewModels;
 

namespace Project.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
               
        }
    }
}
