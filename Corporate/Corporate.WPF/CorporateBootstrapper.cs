using System.Windows;

using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace Corporate.WPF
{
    public class CorporateBootstrapper : UnityBootstrapper
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

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            var moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(Domain.DomainModule));
            moduleCatalog.AddModule(typeof(Service.ServiceModule));           
            moduleCatalog.AddModule(typeof(Expenditures.ExpenditureModule));
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new CorporateLogger();
        }
    }
}
