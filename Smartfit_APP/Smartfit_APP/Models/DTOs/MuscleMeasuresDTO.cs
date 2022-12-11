using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Smartfit_APP.Models.DTOs
{
    public partial class MuscleMeasuresDTO
    {

        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";

        public int IdMuscle { get; set; }

        public int IdUsuario { get; set; }

        public string Musculo { get; set; } = null!;

        public decimal Medida { get; set; }

        public DateTime FechaMedida { get; set; }


        public async Task<ObservableCollection<MuscleMeasuresDTO>> GetMusclesListFull(int userid)
        {

            try
            {
                string RouteSufix = string.Format("MusclesMeasures/GetMusclesList?userid={0}", userid);
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
                    var list = JsonConvert.DeserializeObject<ObservableCollection<MuscleMeasuresDTO>>(response.Content);



                    return list;
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


        public async Task<MuscleMeasuresDTO> GetUserMuscleData(int MuscleID)
        {

            try
            {
                string RouteSufix = string.Format("GetMuscleData?MuscleID={0}",
                    MuscleID);
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
                    var list = JsonConvert.DeserializeObject<List<MuscleMeasuresDTO>>(response.Content);
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
