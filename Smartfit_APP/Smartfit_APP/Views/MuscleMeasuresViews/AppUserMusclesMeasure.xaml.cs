using Smartfit_APP.Models;
using Smartfit_APP.Models.DTOs;
using Smartfit_APP.ViewModels;
using Smartfit_APP.Views.MuscleMeasuresViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartfit_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppUserMusclesMeasure : ContentPage
    {



        MusclesMeasureViewModel VM;
        public MuscleMeasuresDTO MyMuscleMeasuresDTO { get; set; }

        public AppUserMusclesMeasure()
        {



            MyMuscleMeasuresDTO = new MuscleMeasuresDTO();
            InitializeComponent();
            BindingContext = VM = new MusclesMeasureViewModel();
            LoadItemList();
            

        }



        private async void LoadItemList()
        {

            LstMeasure.ItemsSource = await VM.GetFullMusclesList();
            
        }

        private void LstMeasure_ItemTapped(object sender, ItemTappedEventArgs e)
        {
          
        }


        

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppUserMuscleMeasuresEdit());
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppUserMuscleMeasureAdd());
            
        }


















    }
}   