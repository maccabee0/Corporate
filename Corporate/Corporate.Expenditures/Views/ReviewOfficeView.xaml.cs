using System.Windows.Controls;

using Corporate.Expenditures.ViewModels;

using Microsoft.Practices.Unity;

namespace Corporate.Expenditures.Views
{
    /// <summary>
    /// Interaction logic for ReviewOfficeView.xaml
    /// </summary>
    public partial class ReviewOfficeView : UserControl
    {
        public ReviewOfficeView(IUnityContainer container)
        {
            InitializeComponent();
            DataContext = container.Resolve<ReviewOfficeViewModel>();
        }
    }
}
