using System.Windows.Controls;
using Project.ViewModels;

namespace Project.Views
{
    /// <summary>
    /// Interaction logic for DomainView.xaml
    /// </summary>
    public partial class DomainView : UserControl
    {
        public DomainView()
        {
            InitializeComponent();
            DataContext = new DomainViewModel();

        }
    }
}
