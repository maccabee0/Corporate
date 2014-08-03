using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace Corporate.WPF
{
    public class CorporateBootstrapper:UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Shell)this.Shell;
            App.Current.MainWindow.Show();
        }
    }
}
