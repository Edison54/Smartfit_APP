using Smartfit_APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

 
        public AppUserMusclesMeasure()
        {
            InitializeComponent();
            BindingContext = VM = new MusclesMeasureViewModel();
            LoadItemList();
        }



        private async void LoadItemList()
        {

            LstMeasure.ItemsSource = await VM.GetFullInventoryList();
        }

        private void LstMeasure_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void ImageCell_Tapped(object sender, EventArgs e)
        {

        }

       
    }
}   