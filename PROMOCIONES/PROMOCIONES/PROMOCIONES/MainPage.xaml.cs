using PROMOCIONES.Services.Promociones;
using PROMOCIONES.Services.Manager;
using PROMOCIONES.ViewModels.Promociones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PROMOCIONES.views;
using PROMOCIONES.Models;
using Syncfusion.SfDataGrid.XForms;
using Newtonsoft.Json;

namespace PROMOCIONES
{
    public partial class MainPage : ContentPage
    {
        private FicSrvPromocionesList ficSrvPromocionesList = new FicSrvPromocionesList();
        private FicVmPromocionesList ficVmPromocionesList = new FicVmPromocionesList();
        Object data;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Navigate_Button(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FormPromocionesPage());
        }
        private async void goToPromoProdServ(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FicListProdServPage());
        }
        private async void showDetail(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new FicPromocionesDetail(data));
        }

        private async void showUpdatePromo(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FormUpdatePromocionesPage(data));
        }
        private async void deletePromo(object sender, EventArgs args)
        {

            var json = JsonConvert.SerializeObject(data);
            var jsonPromociones = JsonConvert.DeserializeObject<ce_cat_promociones>(json);
            await DisplayAlert("Aviso", "Eliminar promocion: "+ jsonPromociones+"?", "OK");
            await ficSrvPromocionesList.FicMetDeletePromociones(jsonPromociones.IdPromocion);
            await DisplayAlert("Aviso",jsonPromociones.IdPromocion,"OK" );
        }

        private void unlockButtons(object sender, GridTappedEventArgs e)
        {
            btnDetalle.IsEnabled = true;
            btnActualizar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
            //await DisplayAlert("OK",e.RowData.ToString(),"OK");
            data = e.RowData;
            if (aplicaAExist(data)) btnAplicaA.IsEnabled = true;
        }

        private Boolean aplicaAExist(object promocion)
        {
            var json = JsonConvert.SerializeObject(promocion);
            var jsonPromociones = JsonConvert.DeserializeObject<ce_cat_promociones>(json);
            if (jsonPromociones.IdTipoPromocion.Equals("aplicable"))
            {
                return true;
            }else
            return false;
        }
        private void refresh(object sender,EventArgs e)
        {
            ficVmPromocionesList.llenar();
        }
    }
}
