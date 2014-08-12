using System.Windows.Controls;

using Corporate.Expenditures.ViewModels;

using Microsoft.Practices.Unity;

namespace Corporate.Expenditures.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView(IUnityContainer container)
        {
            InitializeComponent();
            this.DataContext = container.Resolve<MainViewModel>();
        }
    }
}
