using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Smartfit_APP.Models.DTOs;
using Smartfit_APP.ViewModels;
using Syncfusion.SfCalendar.XForms;

namespace Smartfit_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppUserMuscleMeasuresEdit : ContentPage
    {



        MusclesMeasureViewModel MuscleVM;



        public MuscleMeasuresDTO MyMuscleMeasuresDTO { get; set; }
        public AppUserMuscleMeasuresEdit()
        {

            MyMuscleMeasuresDTO = new MuscleMeasuresDTO();

            InitializeComponent();

            BindingContext = MuscleVM = new MusclesMeasureViewModel();
           // LoadUserMuscleMeasures()
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (UserImputValidation())
            {




                //EN ESTE CASO LA LLAMADA A LA
                //FUNCIONALIDAD NO SERA POR COMMAND
                //TO DO IMPLEMENTAR COMMAND
                var answer = await DisplayAlert("You want to update your muscle data", "Are you sure?", "Yes", "No");
                if (answer)
                {

                    bool R = await MuscleVM.UpdateMeasure(
            
             Int32.Parse(TxtIdMuscle.Text.Trim()),
             TxtMusculo.Text.Trim(),
             decimal.Parse(TxtMedida.Text.Trim()),
             TxtFechaMedida.Date
             
               );

                    if (R)
                    {
                        await DisplayAlert("Success", "Your data was updated", "OK");
                        await Navigation.PopAsync();

                    }
                    else
                    {
                        await DisplayAlert("Failed", "error trying to establish connection to the server", "OK");
                    }
                }
            }
        }



        private async void LoadUserMuscleMeasures()
        {


            MyMuscleMeasuresDTO = await MuscleVM.GetUserMusclesData(GlobalObjects.GlobalMeasure.IdMuscle);
                TxtIdMuscle.Text = MyMuscleMeasuresDTO.IdMuscle.ToString();
                TxtMusculo.Text = MyMuscleMeasuresDTO.IdUsuario.ToString();
                TxtMedida.Text = MyMuscleMeasuresDTO.Medida.ToString();
                TxtFechaMedida.Date = MyMuscleMeasuresDTO.FechaMedida;


          


        }






        private bool UserImputValidation()
        {
            decimal TEST;
            bool R = false;
            if (TxtIdMuscle.Text != null && !string.IsNullOrEmpty(TxtIdMuscle.Text.Trim()) &&
             
               TxtMusculo.Text != null && !string.IsNullOrEmpty(TxtMusculo.Text.Trim()) &&
               TxtMedida.Text != null && !string.IsNullOrEmpty(TxtMedida.Text.Trim()))
            {



                if (decimal.TryParse(TxtIdMuscle.Text, out TEST) == false)
                {
                    DisplayAlert("Validation error", "Your height should be a number", "OK");
                    TxtIdMuscle.Focus();
                    return false;
                }
            
                if (decimal.TryParse(TxtMusculo.Text, out TEST) == false)
                {
                    DisplayAlert("Validation error", "Your Body Fat should be a number", "OK");
                    TxtMusculo.Focus();
                    return false;
                }
                if (decimal.TryParse(TxtMedida.Text, out TEST) == false)
                {
                    DisplayAlert("Validation error", "Your skeletal muscle should be a number", "OK");
                    TxtMedida.Focus();
                    return false;
                }

                R = true;

            }
            else
            {

                if (TxtIdMuscle.Text == null || string.IsNullOrEmpty(TxtIdMuscle.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your heigt is needed", "OK");
                    TxtIdMuscle.Focus();
                    return false;
                }
                if (TxtMusculo.Text == null || string.IsNullOrEmpty(TxtMusculo.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your  % body fat is needed", "OK");
                    TxtMusculo.Focus();
                    return false;
                }
                if (TxtMedida.Text == null || string.IsNullOrEmpty(TxtMedida.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your skeletal muscle weight is  needed", "OK");
                    TxtMedida.Focus();
                    return false;
                }






            }

            return R;
        }

    }
}