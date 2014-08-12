using System.Windows.Controls;

using Corporate.Expenditures.ViewModels;

using Microsoft.Practices.Unity;

namespace Corporate.Expenditures.Views
{
    /// <summary>
    /// Interaction logic for ReviewView.xaml
    /// </summary>
    public partial class ReviewView : UserControl
    {
        public ReviewView(IUnityContainer container)
        {
            InitializeComponent();
            DataContext = container.Resolve<ReviewViewModel>();
        }
    }
}
