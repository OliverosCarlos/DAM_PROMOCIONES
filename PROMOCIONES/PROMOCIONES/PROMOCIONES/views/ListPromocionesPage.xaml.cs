using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROMOCIONES.Services.Manager;
using PROMOCIONES.Services.Promociones;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PROMOCIONES.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPromocionesPage : ContentPage
	{
        private MFicPromocionesList managerPromociones;
        public ListPromocionesPage(MFicPromocionesList managerPromociones)
        {
            this.managerPromociones = managerPromociones;
        }

        public ListPromocionesPage ( )
		{
            //managerPromociones.FicMetGetPromociones();
            DisplayAlert("Alerta", "ListPromocionesPAge", "OK");
            InitializeComponent ();
		}
        
    }
}