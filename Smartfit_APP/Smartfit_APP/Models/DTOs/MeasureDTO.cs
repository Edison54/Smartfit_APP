using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Smartfit_APP.Models.DTOs
{
    public partial class MeasureDTO
    {

        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";



      

        public int IdMeasure { get; set; }

        public int IdUsuario { get; set; }

        public decimal Altura { get; set; }

        public decimal Peso { get; set; }

        public decimal BodyFat { get; set; }

        public decimal SkeletalMuscle { get; set; }

        public async Task<MeasureDTO> GetMeasureData(int IdUsuario)
        {

            try
            {
                string RouteSufix = string.Format("Measures/GetUserMeasure?userid={0}",
                    IdUsuario);
                string FinalURL = Services.CnnToSmartFitAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToSmartFitAPI.ApiKeyName, Services.CnnToSmartFitAPI.ApiKeyValue);
                request.AddHeader(contentype, mimetype);



                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                //carga de info en un json


                if (statusCode == HttpStatusCode.OK)
                {
                    //carga de info en un json
                    var list = JsonConvert.DeserializeObject<List<MeasureDTO>>(response.Content);
                    var item = list[0];


                    return item;
                }
                else
                {
                    return null;
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
