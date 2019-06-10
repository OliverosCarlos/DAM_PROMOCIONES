using PROMOCIONES.Services.Promociones;
using PROMOCIONES.ViewModels.Promociones;
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
	public partial class FicListProdServPage : ContentPage
	{
        private FicSrvPromocionesList ficSrvPromocionesList = new FicSrvPromocionesList();
        private FicVmPromocionesList ficVmPromocionesList = new FicVmPromocionesList();
        Object data;
        public FicListProdServPage ()
		{
			InitializeComponent ();
		}

        private async void showDetail(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new FicPromocionesDetail(data));
        }
    }
}