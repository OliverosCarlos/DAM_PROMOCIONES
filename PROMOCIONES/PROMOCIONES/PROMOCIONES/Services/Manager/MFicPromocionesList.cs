using System;
using System.Collections.Generic;
using System.Text;
using PROMOCIONES.Services.Promociones;
using PROMOCIONES.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PROMOCIONES.Services.Manager
{
    public class MFicPromocionesList
    {
        public FicSrvPromocionesList ficSrvPromocionesList;

        public MFicPromocionesList( FicSrvPromocionesList service)
        {
            ficSrvPromocionesList = service;
        }

        public Task<ObservableCollection<ce_cat_promociones>> getPromociones()
        {
            return null;
            //return ficSrvPromocionesList.FicMetGetPromociones();
        }

        /*public Task<bool> setPromociones()
        {
            return ficSrvPromocionesList.FicMetAddPromocion();
        }*/
    }
}
