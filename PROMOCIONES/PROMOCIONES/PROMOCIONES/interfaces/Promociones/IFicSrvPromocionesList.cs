using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PROMOCIONES.Models;

namespace PROMOCIONES.interfaces.Promociones
{
    public interface IFicSrvPromocionesList
    {
        Task<IEnumerable<ce_cat_promociones>> FicMetGetListPromociones();
        Task<ObservableCollection<ce_cat_promociones>> FicMetGetPromociones();
        //Task<ce_cat_promociones_aplica_a> GetFicMetGetListPromociones_aplica_a();
        //Task<ce_cat_promociones_cantidad_fisica> GetFicMetGetListPromociones_cantidad_fisica();
        //Task<ce_cat_promo_prod_serv> GetFicMetGetListPromo_prod_Serv();
    }
}
