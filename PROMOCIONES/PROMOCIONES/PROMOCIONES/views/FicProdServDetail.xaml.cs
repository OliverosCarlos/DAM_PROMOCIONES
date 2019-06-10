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
	public partial class FicProdServDetail : ContentPage
	{
		public FicProdServDetail ()
		{
			InitializeComponent ();
		}

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}