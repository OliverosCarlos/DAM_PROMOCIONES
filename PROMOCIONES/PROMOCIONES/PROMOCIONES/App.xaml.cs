using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PROMOCIONES.Services.Promociones;
using PROMOCIONES.views;
using Syncfusion.SfDataGrid.XForms;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PROMOCIONES
{
    public partial class App : Application
    {
        //FicSrvPromocionesList ficSrvPromocionesList;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage( new MainPage() );
        }
    }
}
