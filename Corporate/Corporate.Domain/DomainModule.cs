using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace Corporate.Domain
{
    public class DomainModule : IModule
    {
        private IUnityContainer _unityContainer;
        public DomainModule(IUnityContainer container) { _unityContainer = container; }

        public void Initialize()
        {
            _unityContainer.RegisterType<CorporateContext>(new ContainerControlledLifetimeManager());
        }
    }
}
