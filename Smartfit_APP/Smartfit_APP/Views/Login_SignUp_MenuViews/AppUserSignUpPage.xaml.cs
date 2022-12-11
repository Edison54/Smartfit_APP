using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Smartfit_APP.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartfit_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppUserSignUpPage : ContentPage
    {


        UserViewModel viewModel;
        public AppUserSignUpPage()
        {
            InitializeComponent();
            //se agrega un biding context
            BindingContext = viewModel = new UserViewModel();

        }





        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private bool UserImputValidation()
        {
            bool R = false;
            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
               TxtApellidos.Text != null && !string.IsNullOrEmpty(TxtApellidos.Text.Trim()) &&
               TxtDireccion.Text != null && !string.IsNullOrEmpty(TxtDireccion.Text.Trim()) &&
               TxtTelefono.Text != null && !string.IsNullOrEmpty(TxtTelefono.Text.Trim()) &&
              TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
              TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))

            {
                R = true;

            }
            else
            {

                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your name is needed", "OK");
                    TxtNombre.Focus();
                    return false;
                }
                if (TxtApellidos.Text == null || string.IsNullOrEmpty(TxtApellidos.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your lastname is needed", "OK");
                    TxtApellidos.Focus();
                    return false;
                }
                if (TxtDireccion.Text == null || string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your address  is needed", "OK");
                    TxtDireccion.Focus();
                    return false;
                }
                if (TxtTelefono.Text == null || string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your phone is needed", "OK");
                    TxtTelefono.Focus();
                    return false;
                }
                if (TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your email is needed", "OK");
                    TxtEmail.Focus();
                    return false;
                }
                if (TxtPassword.Text == null || string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    DisplayAlert("Validation error", "A password is needed", "OK");
                    TxtPassword.Focus();
                    return false;
                }


            }

            return R;
        }








        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {


            bool A = false;

            A = await viewModel.GetEmailValidation(TxtEmail.Text.Trim());

            if(A == false) { 



            if (UserImputValidation())
            {




                //EN ESTE CASO LA LLAMADA A LA
                //FUNCIONALIDAD NO SERA POR COMMAND
                //TO DO IMPLEMENTAR COMMAND
                var answer = await DisplayAlert("You want to create your account", "Are you sure?", "Yes", "No");

                if (answer)
                {

                    bool R = await viewModel.AddNewUsuario(
             TxtNombre.Text.Trim(),
             TxtApellidos.Text.Trim(),
             TxtDireccion.Text.Trim(),
             TxtFechaNacimiento.Date,
             TxtTelefono.Text.Trim(),
             TxtEmail.Text.Trim(),
             TxtPassword.Text.Trim()
               );

                    if (R)
                    {
                        await DisplayAlert("Success", "Your account was created", "OK");
                        await Navigation.PopAsync();

                    }
                    else
                    {
                        await DisplayAlert("Failed", "error trying to establish connection to the server", "OK");
                    }
                }
            }
            }
            else
            {
                await DisplayAlert("Failed", "You can use and email that other used", "OK");
            }
        }
    }
}