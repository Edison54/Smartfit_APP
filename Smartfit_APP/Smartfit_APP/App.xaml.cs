using Smartfit_APP.Views;
using Smartfit_APP.Services;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Smartfit_APP
{
    public partial class App : Application
    {

        public App()
        {
            //KEY CALENDARIO
         Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzYzOTU4QDMyMzAyZTMzMmUzMERIMTN4RGRkV3BvTld4UVZkK241K1BGOW1lWEhqMmFaWkdXeVdENk9ORk09");


            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new AppLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
