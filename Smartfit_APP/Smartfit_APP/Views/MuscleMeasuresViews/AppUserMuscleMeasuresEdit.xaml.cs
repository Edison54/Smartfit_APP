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


        int IdMuscle;
        public MuscleMeasuresDTO MyMuscleMeasuresDTO { get; set; }


        public AppUserMuscleMeasuresEdit(int id)
        {
            IdMuscle = id;
            MyMuscleMeasuresDTO = new MuscleMeasuresDTO();

            InitializeComponent();

            BindingContext = MuscleVM = new MusclesMeasureViewModel();
            LoadUserMuscleMeasures(IdMuscle);
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



        private async void LoadUserMuscleMeasures(int id)
        {


            MyMuscleMeasuresDTO = await MuscleVM.GetUserMusclesData(id);
                TxtIdMuscle.Text = MyMuscleMeasuresDTO.IdMuscle.ToString();
                TxtMusculo.Text = MyMuscleMeasuresDTO.Musculo.ToString();
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

      

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {

            var answer = await DisplayAlert("You want to delete this muscle", "Are you sure?", "Yes", "No");

            if (answer)
            {

                bool R = await MuscleVM.Delete(Int32.Parse(TxtIdMuscle.Text.Trim()));
       

                if (R)
                {
                    await DisplayAlert("Success", "Your Muscle was deleted", "OK");
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Failed", "error trying to establish connection to the server", "OK");
                }
            }
        }
    }
       
}



