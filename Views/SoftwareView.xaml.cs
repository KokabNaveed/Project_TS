using System.Windows.Controls;
using Project.ViewModels;

namespace Project.Views
{
    /// <summary>
    /// Interaction logic for SoftwareView.xaml
    /// </summary>
    public partial class SoftwareView : UserControl
    {
        public SoftwareView()
        {
            InitializeComponent();
            DataContext = new SoftwareViewModel();
        }
    }
}
