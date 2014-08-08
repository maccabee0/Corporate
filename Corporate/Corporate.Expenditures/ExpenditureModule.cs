using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corporate.Domain;
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
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, () => _container.Resolve<MainView>());
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, () => _container.Resolve<ReviewOfficeView>());
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, () => _container.Resolve<ReviewView>());
        }
    }
}
