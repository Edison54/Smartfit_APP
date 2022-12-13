using Acr.UserDialogs;
using Smartfit_APP.Models.DTOs;
using Smartfit_APP.ViewModels;
using Smartfit_APP.Views.MuscleMeasuresViews;
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
    public partial class AppUserExercisesMachines : ContentPage
    {

        ExercisesMachinesViewModel VM;
        public ExercisesMachinesDTO MyExercisesMachinesDTO { get; set; }


        public AppUserExercisesMachines()
        {
            MyExercisesMachinesDTO = new ExercisesMachinesDTO();
            InitializeComponent();
            BindingContext = VM = new ExercisesMachinesViewModel();
            LoadItemList();
            
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadItemList();

        }

        private async void LoadItemList()
        {

              LstExercisesMachines.ItemsSource = await VM.GetFullExercisesMachinesList();

        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppUserExercisesMachinesAdd());

        }
       
      
      

        //private async void LstExercisesMachines_ItemTapped(object sender, ItemTappedEventArgs e)
        //{




          


        //    await Navigation.PushAsync(new AppUserExercisesMachinesEdit(id));
        //}

      
       

        private async void LstExercisesMachines_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as ExercisesMachinesDTO ;

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new AppUserExercisesMachinesEdit(selectedItem.IdEjercicio));
            }

            
        }
    }


}
        
