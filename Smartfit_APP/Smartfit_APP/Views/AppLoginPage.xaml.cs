
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartfit_APP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Smartfit_APP.Views;
using Acr.UserDialogs;

namespace Smartfit_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {

        UserViewModel vm;
        public AppLoginPage()
        {

            InitializeComponent();

            this.BindingContext = vm = new UserViewModel();
        }
        private void CmdWatchPassword(Object sender , ToggledEventArgs e)
        {
            if (WatchPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }

        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppUserSignUpPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {



           

            bool R = false;
            if (TxtCorreo.Text != null && !string.IsNullOrEmpty(TxtCorreo.Text.Trim())&&
               TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Checking user data . . .");
                    await Task.Delay(1000);
                    string u = TxtCorreo.Text.Trim();
                    string p = TxtPassword.Text.Trim();
                    R = await vm.UserAccessValidation(u, p);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {

                    UserDialogs.Instance.HideLoading();
                }

            }
            else
            {
                await DisplayAlert("Validation error", "User and password is needed", "OK");
                return;
            }
        

            if (R)
            {
                try
                {
                    //todo: cargar info en un objeto global tipo user (o userDTO)
                    GlobalObjects.GlobalUser = await vm.GetUserData(TxtCorreo.Text.Trim());
               
                
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                    return;
                }



                await Navigation.PushAsync(new AppMenuPage());
                TxtCorreo.Text ="";
                TxtPassword.Text = "";
                //todo ; mostrar la page de seleccion de acciones del sistemas
            }
            else
            {
                await DisplayAlert(":c", "Incorrect Username or password", "OK");
            }
        }
    }
}