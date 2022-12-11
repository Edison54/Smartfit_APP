using Smartfit_APP.Models;
using Smartfit_APP.Models.DTOs;
using Smartfit_APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartfit_APP.Views.MuscleMeasuresViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppUserMuscleMeasureAdd : ContentPage
    {


        MusclesMeasureViewModel MuscleVM;
        public MusclesMeasure MyMuscleMeasures { get; set; }
        public AppUserMuscleMeasureAdd()
        {
            MyMuscleMeasures = new MusclesMeasure();
            InitializeComponent();
            BindingContext = MuscleVM = new MusclesMeasureViewModel();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (UserImputValidation())
            {




                //EN ESTE CASO LA LLAMADA A LA
                //FUNCIONALIDAD NO SERA POR COMMAND
                //TO DO IMPLEMENTAR COMMAND
                var answer = await DisplayAlert("You want to add your muscle data", "Are you sure?", "Yes", "No");
                if (answer)
                {

                    bool R = await MuscleVM.AddNewMuscleMeasure(
             TxtMusculo.Text.Trim(),
             decimal.Parse(TxtMedida.Text.Trim()),
             TxtFechaMedida.Date

               );

                    if (R)
                    {
                        await DisplayAlert("Success", "Your data was Saved", "OK");
                        await Navigation.PopAsync();

                    }
                    else
                    {
                        await DisplayAlert("Failed", "error trying to establish connection to the server", "OK");
                    }
                }
            }
        }


        private bool UserImputValidation()
        {
            decimal TEST;
            bool R = false;
            if (TxtMusculo.Text != null && !string.IsNullOrEmpty(TxtMusculo.Text.Trim()) &&
               TxtMedida.Text != null && !string.IsNullOrEmpty(TxtMedida.Text.Trim()))
            {



              

                if (decimal.TryParse(TxtMedida.Text, out TEST) == false)
                {
                    DisplayAlert("Validation error", "Your muscle measure should be a number", "OK");
                    TxtMedida.Focus();
                    return false;
                }

                R = true;

            }
            else
            {

             
                if (TxtMusculo.Text == null || string.IsNullOrEmpty(TxtMusculo.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your muscle name is needed", "OK");
                    TxtMusculo.Focus();
                    return false;
                }
                if (TxtMedida.Text == null || string.IsNullOrEmpty(TxtMedida.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your muscle measure is  needed", "OK");
                    TxtMedida.Focus();
                    return false;
                }






            }

            return R;
        }
    }
}