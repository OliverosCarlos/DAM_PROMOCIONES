using System;
using System.Collections.Generic;
using System.Text;

using PROMOCIONES.interfaces.Promociones;
using PROMOCIONES.Models;

using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PROMOCIONES.Services.Promociones
{
    internal class FicSrvPromocionesList : IFicSrvPromocionesList
    {
        private readonly HttpClient FicHttpClient;

        public FicSrvPromocionesList()
        {
            this.FicHttpClient = new HttpClient() { MaxResponseContentBufferSize = 256000 };
        }


        public async Task<ce_cat_promociones> FicMetGetListPromociones()
        {
            try
            {
                string url = FicAppSettings.FicUrlBase.ToString() + "api/promociones";
                var response = await FicHttpClient.GetAsync(url);
                var respuesta = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    await App.Current.MainPage.DisplayAlert("ALERTA", respuesta, "OK");
                    return null;
                }
                else if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    await App.Current.MainPage.DisplayAlert("ALERTA", "StatusCode: " + respuesta, "OK");
                    return null;
                }

                var FicJsonConvert = JsonConvert.DeserializeObject<ce_cat_promociones>(await response.Content.ReadAsStringAsync());
                return FicJsonConvert;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error de conexion", "Imposible conectarse con el servidor", "OK");
                return null;
            }
        }

        public async  Task<bool> FicMetAddPromocion(ce_cat_promociones FicDataPromocion)
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
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return false;
            }
        }
    }
}
