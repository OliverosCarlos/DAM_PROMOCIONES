using System;
using System.Collections.Generic;
using System.Text;
using PROMOCIONES.interfaces.Navigation;
using Xamarin.Forms;

namespace PROMOCIONES.Services.Navigation
{
    class FicServiceNavigation : IFicServiceNavigation
    {
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        {
            /*{ typeof(FicViewModeLogin), typeof(FicViewLogin)},
            { typeof(FicViewModeMasterDetailPageMaster), typeof(FicViewLogin)},
            { typeof(FicViewModeMasterDetailPage), typeof(FicViewLogin)},
            { typeof(FicVmPromocionesList), typeof(FicViewLogin)},
            { typeof(FicVmPromocionesConteosItem), typeof(FicViewLogin)}
            { typeof(FicVmPromocionesAcomuladosList), typeof(FicViewLogin)},
            { typeof(FicVmImportarWebApi), typeof(FicViewLogin)},
            { typeof(FicVmExportarWebApi), typeof(FicViewLogin)},
            { typeof(FicVmModelRegistry), typeof(FicViewLogin)},
            { typeof(FicVmRestarPassword), typeof(FicViewLogin)},

            { typeof(FicVmPromocionesDetail), typeof(FicViewLogin)},
            { typeof(FicVmPromocionesAcomuladosDetail), typeof(FicViewLogin)},
            { typeof(FicVmPromocionesConteoDetail), typeof(FicViewLogin)},*/
        };

        public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
        {
            Type FicPageType = FicViewModelRouting[FicDestinationType];
            var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

            if (FicPage != null)
            {
                var mdp = Application.Current.MainPage as MasterDetailPage;
                mdp.Detail.Navigation.PushAsync(FicPage);
            }
        }

        public void FicMetNavigateBack()
        {
            var mdp = Application.Current.MainPage as MasterDetailPage;
            mdp.Detail.Navigation.PopAsync();
            //Application.Current.MainPage.Navigation.PopAsync(true);
        }
    }//CLASS
}//NAMESPACE
