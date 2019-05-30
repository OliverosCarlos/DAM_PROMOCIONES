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
                System.Diagnostics.Debug.WriteLine("      ruta: ", FicAppSettings.FicUrlBase.ToString() + "api/promociones");
                string url = FicAppSettings.FicUrlBase.ToString() + "api/promociones";
                var response = await FicHttpClient.GetAsync(url);
                var respuesta = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(" -----------------respuesta-------------", respuesta);
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

        public async Task<bool> FicMetAddPromocion(ce_cat_promociones FicDataPromocion)
        {
            try
            {
                //if (CrossConnectivity.Current.IsConnected)
                //{
                string url = FicAppSettings.FicUrlBase.ToString() + "api/promociones";

                HttpResponseMessage response = await FicHttpClient.PostAsync(
                    new Uri(string.Format(url, string.Empty)),
                    new StringContent(JsonConvert.SerializeObject(FicDataPromocion), Encoding.UTF8, "application/json"));
                var respuesta = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await App.Current.MainPage.DisplayAlert("ALERTA", respuesta, "OK");
                    return false;
                }
                else if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    await App.Current.MainPage.DisplayAlert("ALERTA", "StatusCode: " + response.StatusCode.ToString(), "OK");
                    return false;
                }
                //var FicMessageResponse = await  response.Content:ReadAsStringAsync();
                await App.Current.MainPage.DisplayAlert("REGISTRADO CON EXITO ", await response.Content.ReadAsStringAsync(), "OK");
                return true;
                //}
                // await App.Current.MainPage.DisplayAlert("ALERTA", "Sin conexión a internet.", "OK");
                // return false;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return false;
            }
        }

        public Task<IEnumerable<ce_cat_promociones>> FicMetGetListPromociones()
        {
            throw new NotImplementedException();
        }
    }
}
