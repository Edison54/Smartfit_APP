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
    public partial class Usuario
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";



        public Usuario()
        {
           
        }

        public int IdUsuario { get; set; }

       

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Rol { get; set; } = null;

        public string Direccion { get; set; } = null!;

        public DateTime FechaInicio { get; set; } 

        public DateTime FechaNacimiento { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<ExercisesMachine> ExercisesMachines { get; set; }
        public virtual ICollection<Measure> Measures { get; set; }
        public virtual ICollection<MusclesMeasure> MusclesMeasures { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; } 

        public async Task<bool> AddUsuario()
        {

            try
            {
                string RouteSufix = string.Format("Usuarios");
                string FinalURL = Services.CnnToSmartFitAPI.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                //agregar la info de seguridad del api , aqui va la apikey

                request.AddHeader(Services.CnnToSmartFitAPI.ApiKeyName, Services.CnnToSmartFitAPI.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                //Tenemos que serializar la clase para poder enviarla a la api

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



       







        public async Task<bool> ValidateLogin()
        {

            try
            {
                
                string RouteSufix = string.Format("Usuarios/ValidateLogin?UserName={0}&UserPassword={1}",
                   this.Correo, this.Password);
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

