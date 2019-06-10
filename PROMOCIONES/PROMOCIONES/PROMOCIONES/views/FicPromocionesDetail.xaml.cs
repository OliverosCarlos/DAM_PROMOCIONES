using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROMOCIONES.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using PROMOCIONES.Services.Promociones;
namespace PROMOCIONES.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicPromocionesDetail : ContentPage
	{
        FicSrvPromocionesList ficSrvPromocionesList = new FicSrvPromocionesList();

        public FicPromocionesDetail (Object data)
		{

            var json = JsonConvert.SerializeObject(data);
            var jsonPromociones = JsonConvert.DeserializeObject<ce_cat_promociones>(json);

            getOnePromo(jsonPromociones);
            
            InitializeComponent ();
            
            //DisplayAlert("Aviso",jsonPromociones.DesPromocion,"OK" );
		}

        public async void getOnePromo(ce_cat_promociones data)
        {
            var promocion  = await ficSrvPromocionesList.FicMetGetOnePromocion(data.IdPromocion);
            //await DisplayAlert("promocion", promocion[0].DesPromocion,"OK");
            var promo = promocion[0];
            BindingContext = promo;
        }

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}