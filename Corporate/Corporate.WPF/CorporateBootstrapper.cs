using System.Windows;

using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace Corporate.WPF
{
    public class CorporateBootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell)Shell;
            Application.Current.MainWindow.Show();
        }
    }
}
