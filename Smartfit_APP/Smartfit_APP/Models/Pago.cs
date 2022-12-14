using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Smartfit_APP.Services;

namespace Smartfit_APP.Models
{
    public partial class Pago
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";



        public Pago()
        {
           
        }

        public int IdPago { get; set; }

        public int IdUsuario { get; set; }

        public DateTime? FechaPago { get; set; }

        public string Estado { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;


        public async Task<bool> AddPago()
        {

            try
            {
                string RouteSufix = string.Format("Pagos");
                string FinalURL = Services.CnnToSmartFitAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToSmartFitAPI.ApiKeyName, Services.CnnToSmartFitAPI.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                //Tenemos que serializar la clase para poder enviarla a la api
                string SerialClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                //carga de info en un json


                if (statusCode == HttpStatusCode.Created)
                {
                    //carga de info en un json

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                string msg = ex.Message;

                //to do guardar errores en una bitacora.
                throw;
            }

        }

     

    }
}

