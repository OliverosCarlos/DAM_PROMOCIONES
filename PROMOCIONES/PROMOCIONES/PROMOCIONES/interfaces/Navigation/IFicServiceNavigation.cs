using System;
using System.Collections.Generic;
using System.Text;

namespace PROMOCIONES.interfaces.Navigation
{
    public interface IFicServiceNavigation
    {
        void FicMetNavigateTo<FicDestinationViewModel>(object FicNavigationContext = null);
        void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null);
        void FicMetNavigateBack();
    }
}
