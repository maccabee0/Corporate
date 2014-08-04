using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Corporate.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
#if (DEBUG)
            RunInDebugMode();
#else
            RunInReleaseMode();
#endif
        }

        private static void RunInDebugMode()
        {
            var bootstrapper = new CorporateBootstrapper();
            bootstrapper.Run();
        }

        private static void RunInReleaseMode()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            UnhandledException(e.ExceptionObject as Exception);
        }

        private static void UnhandledException(Exception ex)
        {
            if(ex==null)
                return;

            //ExceptionPolicy.H
        }
    }
}
