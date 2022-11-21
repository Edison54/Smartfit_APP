using Smartfit_APP.ViewModels;
using Smartfit_APP.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Smartfit_APP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
          
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
