using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PROMOCIONES.interfaces.Promociones;
using PROMOCIONES.Models;
using PROMOCIONES.views;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Collections.ObjectModel;
namespace PROMOCIONES.Services.Promociones
{
    public class FicSrvPromocionesList : IFicSrvPromocionesList
    {
        private readonly HttpClient FicHttpClient = new HttpClient();

        public  async Task<ObservableCollection<ce_cat_promociones>> FicMetGetPromociones()
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine("      ruta: ", FicAppSettings.FicUrlBase.ToString() + "api/promociones");
                string url = FicAppSettings.FicUrlBase.ToString() + "api/promociones";
                var response = await FicHttpClient.GetAsync(url);
                var respuesta = await response.Content.ReadAsStringAsync();
                var FicJsonConvert = JsonConvert.DeserializeObject<ObservableCollection<ce_cat_promociones>>(respuesta);
                System.Diagnostics.Debug.WriteLine(" msg", FicJsonConvert);
                return FicJsonConvert;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("---------------error----------------",e);
                return null;
            }
        }

        public async Task<ObservableCollection<grid_promociones>> FicMetGetGridPromociones()
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine("      ruta: ", FicAppSettings.FicUrlBase.ToString() + "api/promociones");
                string url = FicAppSettings.FicUrlBase.ToString() + "api/promociones/grid";
                var response = await FicHttpClient.GetAsync(url);
                var respuesta = await response.Content.ReadAsStringAsync();
                var FicJsonConvert = JsonConvert.DeserializeObject<ObservableCollection<grid_promociones>>(respuesta);
                System.Diagnostics.Debug.WriteLine(" msg", FicJsonConvert);
                return FicJsonConvert;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("---------------error----------------", e);
                return null;
            }
        }

        public async Task<ObservableCollection<ce_cat_promociones>> FicMetGetOnePromocion(string idPromocion)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("      id: ", idPromocion);
                string url = FicAppSettings.FicUrlBase.ToString() + "api/promociones/listar?idpromocion="+idPromocion;
                var response = await FicHttpClient.GetAsync(url);
                var respuesta = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine("      Respuesta: ", respuesta);
                var FicJsonConvert = JsonConvert.DeserializeObject<ObservableCollection<ce_cat_promociones>>(respuesta);
                System.Diagnostics.Debug.WriteLine(" msg", FicJsonConvert);
                return FicJsonConvert;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("---------------error----------------", e);
                return null;
            }
        }

        public async Task<bool> FicMetAddPromocion(ce_cat_promociones FicDataPromocion)
        {
            try
            {
                //await App.Current.MainPage.DisplayAlert("Dato actual ",FicDataPromocion.IdPromocion.ToString(), "OK");

                string url = FicAppSettings.FicUrlBase.ToString() + "api/promociones";

                HttpResponseMessage response = await FicHttpClient.PostAsync(
                    url,
                    //new Uri(string.Format(url, string.Empty)),
                    new StringContent(JsonConvert.SerializeObject(FicDataPromocion), Encoding.UTF8, "application/json"));

                var respuesta = await response.Content.ReadAsStringAsync();
                await App.Current.MainPage.DisplayAlert("REGISTRADO CON EXITO ", respuesta, "OK");
                return true;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return false;
            }
        }

        public async Task<bool> FicMetDeletePromociones(string idpromocion)
        {
            try
            {
                await App.Current.MainPage.DisplayAlert("ALERTA", idpromocion, "OK");
                string url = FicAppSettings.FicUrlBase.ToString() + "api/promociones?idpromocion="+idpromocion;
                var response = await FicHttpClient.DeleteAsync(url);
                var respuesta = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(" msg", respuesta);
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("---------------error----------------", e);
                return false;
            }
        }

        public async Task<bool> FicMetUpdatePromocion(ce_cat_promociones FicDataPromocion,string idPromocion)
        {
            try
            {
                //await App.Current.MainPage.DisplayAlert("Dato actual ",FicDataPromocion.IdPromocion.ToString(), "OK");

                string url = FicAppSettings.FicUrlBase.ToString() + "api/promociones?idpromocion="+idPromocion;
                await App.Current.MainPage.DisplayAlert("ACTUALIZANDO ", url, "OK");
                HttpResponseMessage response = await FicHttpClient.PutAsync(
                    url,
                    //new Uri(string.Format(url, string.Empty)),
                    new StringContent(JsonConvert.SerializeObject(FicDataPromocion), Encoding.UTF8, "application/json"));

                var respuesta = await response.Content.ReadAsStringAsync();
                await App.Current.MainPage.DisplayAlert("ACTUALIZADO CON EXITO ", respuesta, "OK");
                return true;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("ERROR", e.Message.ToString(), "OK");
                return false;
            }
        }
        public Task<IEnumerable<ce_cat_promociones>> FicMetGetListPromociones()
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<grid_prod_serv>> FicMetGetGridProdServ()
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine("      ruta: ", FicAppSettings.FicUrlBase.ToString() + "api/promociones");
                string url = FicAppSettings.FicUrlBase.ToString() + "api/prod-serv/grid";
                var response = await FicHttpClient.GetAsync(url);
                var respuesta = await response.Content.ReadAsStringAsync();
                var FicJsonConvert = JsonConvert.DeserializeObject<ObservableCollection<grid_prod_serv>>(respuesta);
                System.Diagnostics.Debug.WriteLine(" msg", FicJsonConvert);
                return FicJsonConvert;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("---------------error----------------", e);
                return null;
            }
        }
    }
}
/*if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
{
    System.Diagnostics.Debug.WriteLine(" encontrado ",respuesta);
    return null;
}
else if (response.StatusCode != System.Net.HttpStatusCode.OK)
{
    System.Diagnostics.Debug.WriteLine("ok",respuesta);
    return null;
}*/
