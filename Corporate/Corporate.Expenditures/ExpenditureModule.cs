using Corporate.Domain;
using Corporate.Expenditures.ViewModels;
using Corporate.Expenditures.Views;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Corporate.Expenditures
{
    public class ExpenditureModule : IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public ExpenditureModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<ReviewOfficeViewModel>();
            _container.RegisterType<ReviewViewModel>();
            _container.RegisterType<EditViewModel>();
            _container.RegisterType<CategoryViewModel>();
            _container.RegisterType<object,MainView>(ExpenditureKeys.MainView);
            _container.RegisterType<object,ReviewOfficeView>(ExpenditureKeys.ReviewOfficeView);
            _container.RegisterType<object, ReviewView>(ExpenditureKeys.ReviewView);
            _regionManager.RequestNavigate(RegionNames.MainRegion, ExpenditureKeys.MainView);
        }
    }
}
