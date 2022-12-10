using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartfit_APP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppMenuPage 
	{

   

   
        public AppMenuPage ()
		{
			InitializeComponent ();





        }

        private async void BtnCalendar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppCalendarPage());
        }



        private async void BtnHealth_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppUserMeasures());
        }

        private async void BtnMeasures_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppUserMusclesMeasure());
        }
    }
}