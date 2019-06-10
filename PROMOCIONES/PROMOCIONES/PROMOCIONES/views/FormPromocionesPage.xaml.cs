using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PROMOCIONES.Models;
using PROMOCIONES.Services.Promociones;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PROMOCIONES.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormPromocionesPage : ContentPage
	{
        public ce_cat_promociones promociones =  new ce_cat_promociones();
        public FicSrvPromocionesList srvPromociones = new FicSrvPromocionesList();
		public FormPromocionesPage ()
		{
			InitializeComponent ();
		}

        public async void addPromotion(object sender, EventArgs e)
        {
                promociones.IdPromocion = txtIdPromo.Text;
                promociones.DesPromocion = txtDesPromo.Text;
                promociones.FechaExpiraIni = txtFechaExpiraIni.Text;
                promociones.FechaExpiraFin = txtFechaExpiraFin.Text;
                promociones.Valor = txtValor.Text;
                promociones.Activo = txtActivo.Text;
                promociones.Borrado = txtBorrado.Text;
                promociones.IdTipoPromocion = txtIdTipoPromo.Text;
                promociones.IdTipoDescuento = txtIdTipoDescuento.Text;

                //await DisplayAlert("alerta", promociones.IdPromocion.ToString(), "ok");
                await srvPromociones.FicMetAddPromocion(promociones);
        }

    }
}