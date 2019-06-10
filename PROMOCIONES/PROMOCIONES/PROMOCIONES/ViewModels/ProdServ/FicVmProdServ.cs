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
    public class FicVmProdServ : INotifyPropertyChanged
    {
        public ObservableCollection<grid_prod_serv> FicSfDataGrid_ItemSource_ProdServ { get; set; }
        public ObservableCollection<ce_cat_prod_serv2> FicAllData_ProdServ { get; set; }
        private FicSrvPromocionesList ficSrvPromocionesList = new FicSrvPromocionesList();

        public FicVmProdServ()
        {
            this.FicSfDataGrid_ItemSource_ProdServ = new ObservableCollection<grid_prod_serv>();
            this.llenar();
        }//CONSTRUCTOR

        public async void llenar()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(" llenando");
                var source_local_prodServ = await ficSrvPromocionesList.FicMetGetGridProdServ();
                if (source_local_prodServ != null)
                {
                    FicSfDataGrid_ItemSource_ProdServ.Clear();
                    foreach (grid_prod_serv prodServ in source_local_prodServ)
                    {
                        System.Diagnostics.Debug.WriteLine(" msg", prodServ);
                        FicSfDataGrid_ItemSource_ProdServ.Add(prodServ);
                        RaisePropertyChanged("FicSfDataGrid_ItemSource_Promociones");
                    }
                }//LLENAR EL GRID

            }
            catch (Exception e)
            {
                //await App.Current.MainPage.DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

