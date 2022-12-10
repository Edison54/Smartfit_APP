using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Smartfit_APP.Services;

namespace Smartfit_APP.Models.DTOs
{
    public partial class UsuarioDTO
    {



        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";



       

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




        public async Task<UsuarioDTO> GetUserData(string correo)
        {

            try
            {
                string RouteSufix = string.Format("Usuarios/GetUserInfo?email={0}",
                    correo);
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
                    var list = JsonConvert.DeserializeObject<List<UsuarioDTO>>(response.Content);
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
