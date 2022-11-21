using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using Smartfit_APP.Models;

namespace Smartfit_APP.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

       

        public Usuario MyUsuario { get; set; }
        public UserViewModel()
        {
          
         
            MyUsuario = new Usuario();
        }


        public async Task<bool> AddNewUsuario(

            string pNombre,
            string pApellidos,
            string pDireccion,
            DateTime pFechaNacimiento ,
            string pTelefono,
            string pEmail,
            string pPassword,
            string pRol = "Usuario"
           
            )




        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {

                MyUsuario.Nombre = pNombre;
                MyUsuario.Apellidos = pApellidos;
                MyUsuario.Rol = pRol;
                MyUsuario.Direccion = pDireccion;
                //MyUsuario.FechaNacimiento = pFechaInicio;
                MyUsuario.FechaNacimiento = pFechaNacimiento;
                MyUsuario.Telefono = pTelefono;
                MyUsuario.Correo = pEmail;
                MyUsuario.Password = pPassword;
            

                bool R = await MyUsuario.AddUsuario();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }




        //funcion de ingreso al app del usuario

        public async Task<bool> UserAccessValidation(string pEmail, string pUserPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUsuario.Correo = pEmail;
                MyUsuario.Password = pUserPassword;

                bool R = await MyUsuario.ValidateLogin();

                return R;

            }
            catch (Exception)
            {

                return false;
                throw;
            }
            finally
            { IsBusy = false; }


        }


    }


  
}
