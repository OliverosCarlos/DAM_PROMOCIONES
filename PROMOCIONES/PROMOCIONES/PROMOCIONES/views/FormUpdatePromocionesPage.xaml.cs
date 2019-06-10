using Newtonsoft.Json;
using PROMOCIONES.Models;
using PROMOCIONES.Services.Promociones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PROMOCIONES.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormUpdatePromocionesPage : ContentPage
	{
        public ce_cat_promociones promociones = new ce_cat_promociones();
        public string idpromo;

        FicSrvPromocionesList ficSrvPromocionesList = new FicSrvPromocionesList();
        public FormUpdatePromocionesPage (object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var jsonPromociones = JsonConvert.DeserializeObject<ce_cat_promociones>(json);
            this.idpromo = jsonPromociones.IdPromocion;
            getOnePromo(jsonPromociones);
            InitializeComponent ();
		}

        public async void getOnePromo(ce_cat_promociones data)
        {
            var promocion = await ficSrvPromocionesList.FicMetGetOnePromocion(data.IdPromocion);
            //await DisplayAlert("promocion", promocion[0].DesPromocion,"OK");
            var promo = promocion[0];
            BindingContext = promo;
        }

        async void updatePromotion(object sender, EventArgs args)
        {
            
            promociones.DesPromocion = txtDesPromo.Text;
            promociones.FechaExpiraIni = txtFechaExpiraIni.Text;
            promociones.FechaExpiraFin = txtFechaExpiraFin.Text;
            promociones.Valor = txtValor.Text;
            promociones.FechaUltMod = "hoy";
            promociones.UsuarioMod = "Robo";
            promociones.IdTipoPromocion = txtIdTipoPromo.Text;
            promociones.IdTipoDescuento = txtIdTipoDescuento.Text;

            await DisplayAlert("alerta", promociones.FechaExpiraFin, "ok");
            await ficSrvPromocionesList.FicMetUpdatePromocion(promociones, this.idpromo);
        }
    }
}