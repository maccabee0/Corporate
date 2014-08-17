using System.Windows.Controls;
using Corporate.Expenditures.ViewModels;
using Microsoft.Practices.Unity;

namespace Corporate.Expenditures.Views
{
    /// <summary>
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        public EditView()
        {
            InitializeComponent();
            DataContext = new EditViewModel();
        }
    }
}
