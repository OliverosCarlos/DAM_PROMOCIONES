using PROMOCIONES.Services.Promociones;
using PROMOCIONES.Services.Manager;
using PROMOCIONES.ViewModels.Promociones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PROMOCIONES.Models;
using Syncfusion.SfDataGrid.XForms;

namespace PROMOCIONES
{
    public partial class MainPage : ContentPage
    {

 

        public MainPage()
        {
 


            //FicSrvPromocionesList promocionesService = new FicSrvPromocionesList();
  
            DisplayAlert("Alerta", "Probando", "OK");
            InitializeComponent();
        }
        
    }
}
