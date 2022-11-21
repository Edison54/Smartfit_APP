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
    public partial class MusclesMeasure
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";



        public MusclesMeasure()
        {
           
        }
        public int IdMuscle { get; set; }

        public int IdUsuario { get; set; }

        public string Musculo { get; set; } = null!;

        public decimal Medida { get; set; }

        public DateTime FechaMedida { get; set; }

        
        public async Task<bool> AddMusclesMeasure()
        {

            try
            {
                string RouteSufix = string.Format("MusclesMeasures");
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

