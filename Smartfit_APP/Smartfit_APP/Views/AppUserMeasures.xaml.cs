using Smartfit_APP.Models;
using Smartfit_APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Smartfit_APP.Models.DTOs;

namespace Smartfit_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppUserMeasures : ContentPage
    {
        UserMeasuresViewModel viewModel2;
        UserViewModel viewModel;

        public Measure MyMeasure { get; set; }

        public MeasureDTO MyMeasureDTO { get; set; }
        public AppUserMeasures()
        {
           
            InitializeComponent();
            MyMeasure = new Measure();
            MyMeasureDTO = new MeasureDTO();

            //se agrega un biding context
            BindingContext = viewModel = new UserViewModel();

            BindingContext = viewModel2 = new UserMeasuresViewModel();

            //llenar campso con data del user con el usuario global.
            LoadUserMeasures();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (UserImputValidation())
            {
                bool X = await viewModel2.GetMeasuresInfo();




                if (X){


                  


                    var answer = await DisplayAlert("You want to update your health data", "Are you sure?", "Yes", "No");



                    if (answer)
                    {

                        bool R = await viewModel2.UpdateMeasure(
                 Int32.Parse(TxtIdMeasure.Text.Trim()),
                 decimal.Parse(TxtAltura.Text.Trim()),
                 decimal.Parse(TxtPeso.Text.Trim()),
                 decimal.Parse(TxtBodyFat.Text.Trim()),
                 decimal.Parse(TxtSkeletalMuscle.Text.Trim())

                   ); ;

                        if (R)
                        {
                            await DisplayAlert("Success", "Your data was saved", "OK");
                           

                        }
                        else
                        {
                            await DisplayAlert("Failed", "error trying to establish connection to the server", "OK");
                        }
                    }





                }
                else
                {

                    var answer = await DisplayAlert("You want to add your health data", "Are you sure?", "Yes", "No");



                    if (answer)
                    {

                        bool R = await viewModel2.AddNewMeasure(
                 decimal.Parse(TxtAltura.Text.Trim()),
                 decimal.Parse(TxtPeso.Text.Trim()),
                 decimal.Parse(TxtBodyFat.Text.Trim()),
                 decimal.Parse(TxtSkeletalMuscle.Text.Trim())

                   ); ;

                        if (R)
                        {
                            await DisplayAlert("Success", "Your data was saved", "OK");
                            

                        }
                        else
                        {
                            await DisplayAlert("Failed", "error trying to establish connection to the server", "OK");
                        }
                    }
                }
                //EN ESTE CASO LA LLAMADA A LA
                //FUNCIONALIDAD NO SERA POR COMMAND
                //TO DO IMPLEMENTAR COMMAND
               
            }
        }

     
           

        private async void LoadUserMeasures()
        {

        
           MyMeasureDTO = await viewModel2.GetMeasures();
            if (MyMeasureDTO != null) {
                TxtIdMeasure.Text = MyMeasureDTO.IdMeasure.ToString();
                TxtAltura.Text = MyMeasureDTO.Altura.ToString();
                TxtPeso.Text = MyMeasureDTO.Peso.ToString();
                TxtBodyFat.Text = MyMeasureDTO.BodyFat.ToString();
                TxtSkeletalMuscle.Text = MyMeasureDTO.SkeletalMuscle.ToString();


            }
            else
            {
                TxtIdMeasure.Text = "";
                TxtAltura.Text = "0";
                TxtPeso.Text = "0";
                TxtBodyFat.Text = "0";
                TxtSkeletalMuscle.Text = "0";
            }
           

        }
        private bool UserImputValidation()
        {
            bool R = false;
            if (TxtAltura.Text != null && !string.IsNullOrEmpty(TxtAltura.Text.Trim()) &&
               TxtPeso.Text != null && !string.IsNullOrEmpty(TxtPeso.Text.Trim()) &&
               TxtBodyFat.Text != null && !string.IsNullOrEmpty(TxtBodyFat.Text.Trim()) &&
               TxtSkeletalMuscle.Text != null && !string.IsNullOrEmpty(TxtSkeletalMuscle.Text.Trim()))

            {
                R = true;

            }
            else
            {

                if (TxtAltura.Text == null || string.IsNullOrEmpty(TxtAltura.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your heigt is needed", "OK");
                    TxtAltura.Focus();
                    return false;
                }
                if (TxtPeso.Text == null || string.IsNullOrEmpty(TxtPeso.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your Weight is needed", "OK");
                    TxtPeso.Focus();
                    return false;
                }
                if (TxtBodyFat.Text == null || string.IsNullOrEmpty(TxtBodyFat.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your  % body fat is needed", "OK");
                    TxtBodyFat.Focus();
                    return false;
                }
                if (TxtSkeletalMuscle.Text == null || string.IsNullOrEmpty(TxtSkeletalMuscle.Text.Trim()))
                {
                    DisplayAlert("Validation error", "Your skeletal muscle weight is  needed", "OK");
                    TxtSkeletalMuscle.Focus();
                    return false;
                }
              

            }

            return R;
        }
    }






  










    

    }
