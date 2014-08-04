using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Corporate.Interfaces.Repositories;
using Corporate.Service.Repositories;

namespace Corporate.Service
{
    public class ServiceModule:IModule
    {
        private IUnityContainer _container;

        public ServiceModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<ILoggerFacade, ExceptionRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IExpenseLogRepository, ExpenseLogRepository>();
            _container.RegisterType<IOfficeRepository, OfficeRepository>();
            _container.RegisterType<IExpenseRepository, ExpenseRepository>();
        }
    }
}
