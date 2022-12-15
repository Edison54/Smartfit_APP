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

namespace Smartfit_APP.Views.ExercisesMachines
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppUserExercisesMachinesAdd : ContentPage
    {


        ExercisesMachinesViewModel VM;
        public ExercisesMachinesDTO MyExercisesMachinesDTO { get; set; }

        public ExercisesMachine MyExercisesMachines { get; set; }




        public AppUserExercisesMachinesAdd()
        {



            MyExercisesMachines = new ExercisesMachine();
            InitializeComponent();
            BindingContext = VM = new ExercisesMachinesViewModel();
            LoadUserExercises();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (UserImputValidation())
            {




                //EN ESTE CASO LA LLAMADA A LA
                //FUNCIONALIDAD NO SERA POR COMMAND
                //TO DO IMPLEMENTAR COMMAND
                var answer = await DisplayAlert("You want to add your exercise data", "Are you sure?", "Yes", "No");
                if (answer)
                {

                    bool R = await VM.AddNewExerciseMachine(
             TxtNameExercise.Text.Trim(),
             Int32.Parse(TxtPeso.Text.Trim()),
             TxtCantidadRepeticiones.Text.Trim(),
             TxtTiempo.Text.Trim()


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

        private  void LoadUserExercises()
        {



            TxtNameExercise.Text = "0";
            TxtPeso.Text = "0";
            TxtCantidadRepeticiones.Text = "0";
            TxtTiempo.Text = "0";




        }

        private bool UserImputValidation()
        {
            decimal TEST;
            bool R = false;
            if (TxtNameExercise.Text != null && !string.IsNullOrEmpty(TxtNameExercise.Text.Trim()) &&
               TxtPeso.Text != null && !string.IsNullOrEmpty(TxtPeso.Text.Trim()) &&
               TxtCantidadRepeticiones.Text != null && !string.IsNullOrEmpty(TxtCantidadRepeticiones.Text.Trim()) &&
               TxtTiempo.Text != null && !string.IsNullOrEmpty(TxtTiempo.Text.Trim())
               )
            {





                if (decimal.TryParse(TxtPeso.Text, out TEST) == false)
                {
                    DisplayAlert("Validation error", "Your Weight should be a number", "OK");
                    TxtPeso.Focus();
                    return false;
                }

                R = true;

            }
            else
            {


                if (TxtNameExercise.Text == null || string.IsNullOrEmpty(TxtNameExercise.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your exercise name  is needed", "OK");
                    TxtNameExercise.Focus();
                    return false;
                }
                if (TxtPeso.Text == null || string.IsNullOrEmpty(TxtPeso.Text.Trim()))
                {
                  
                    DisplayAlert("Validation error", "Your weight is  needed", "OK");
                    TxtPeso.Focus();
                    return false;
                }
                if (TxtCantidadRepeticiones.Text == null || string.IsNullOrEmpty(TxtCantidadRepeticiones.Text.Trim()))
                {
                  
                    DisplayAlert("Validation error", "Your repetitions is needed", "OK");
                    TxtCantidadRepeticiones.Focus();
                    return false;
                  
                }
                if (TxtTiempo.Text == null || string.IsNullOrEmpty(TxtTiempo.Text.Trim()))
                {
                    
                    DisplayAlert("Validation error", "Your time is needed", "OK");
                    TxtTiempo.Focus();
                    return false;
                }



            }

            return R;
        }
    }
}