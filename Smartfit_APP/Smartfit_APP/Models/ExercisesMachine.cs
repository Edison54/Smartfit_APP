﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Smartfit_APP.Services;

namespace Smartfit_APP.Models
{
    public partial class ExercisesMachine
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";



        public ExercisesMachine()
        {
           
        }

        public int IdEjercicio { get; set; }

        public int IdUsuario { get; set; }

        public string NameExercise { get; set; } = null!;

        public int Peso { get; set; }

        public string CantidadRepeticiones { get; set; } = null!;

        public string Tiempo { get; set; } = null!;

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        
       public async Task<bool> AddExercisesMachine()
        {

            try
            {
                string RouteSufix = string.Format("ExercisesMachines");
                string FinalURL = Services.CnnToSmartFitAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToSmartFitAPI.ApiKeyName, Services.CnnToSmartFitAPI.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;




                string SerialClass = JsonConvert.SerializeObject(this, settings);

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
        public async Task<bool> UpdateExerciseMachine(int id)
        {

            try
            {
                string RouteSufix = string.Format("ExercisesMachines/{0}", id);
                string FinalURL = Services.CnnToSmartFitAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Put);// se usa put o patch

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToSmartFitAPI.ApiKeyName, Services.CnnToSmartFitAPI.ApiKeyValue);
                request.AddHeader(contentype, mimetype);



                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;

                //Tenemos que serializar la clase para poder enviarla a la api
                string SerialClass = JsonConvert.SerializeObject(this, settings);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                //carga de info en un json


                if (statusCode == HttpStatusCode.OK)
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

