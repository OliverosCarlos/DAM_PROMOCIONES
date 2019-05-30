using System;
using System.Collections.Generic;
using System.Text;

using PROMOCIONES.interfaces.Promociones;
using PROMOCIONES.interfaces.Navigation;
using PROMOCIONES.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PROMOCIONES.Services.Promociones;

namespace PROMOCIONES.ViewModels.Promociones
{
    public class FicVmPromocionesList
    {
        public ObservableCollection<ce_cat_promociones> FicSfDataGrid_ItemSource_Promociones { get; set; }
        private FicSrvPromocionesList ficSrvPromocionesList = new FicSrvPromocionesList();

        public FicVmPromocionesList()
        {
            this.FicSfDataGrid_ItemSource_Promociones = new ObservableCollection<ce_cat_promociones>();
            this.llenar();
        }//CONSTRUCTOR

        public async void llenar() {
            try
            {
                System.Diagnostics.Debug.WriteLine(" llenando");
                var source_local_prom = await ficSrvPromocionesList.FicMetGetPromociones();
                if (source_local_prom != null)
                {
                    FicSfDataGrid_ItemSource_Promociones.Clear();
                    foreach (ce_cat_promociones prom in source_local_prom)
                    {
                        System.Diagnostics.Debug.WriteLine(" msg", prom);
                        FicSfDataGrid_ItemSource_Promociones.Add(prom);
                    }
                }//LLENAR EL GRID

            }
            catch (Exception e)
            {
                //await App.Current.MainPage.DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

    }
}
