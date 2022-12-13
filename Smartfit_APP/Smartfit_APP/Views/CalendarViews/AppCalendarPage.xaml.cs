using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Smartfit_APP.ViewModels;
namespace Smartfit_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppCalendarPage : ContentPage
    {


        bool paid = false;
        bool del = false;
        bool attend = false;
        public AppCalendarPage()
        {
            InitializeComponent();
        }

       private void BtnDel_Clicked(object sender, EventArgs e)
        {
            del = true;
            attend = false;
            paid = false;
        }


    
        private void BtnAttend_Clicked(object sender, EventArgs e)
        {
            attend = true;
            paid = false;
            del = false;
        }


        private void BtnPaid_Clicked(object sender, EventArgs e)
        {
           
            paid = true;
            attend = false;
            del = false;
        }

       
        private void calendar_OnCalendarTapped(object sender, Syncfusion.SfCalendar.XForms.CalendarTappedEventArgs e)

        {

            
                if (del == true)
                {
                   

                foreach (var appointment in (CalendarEventCollection)e.SelectedAppointment)

                {

                    viewmodel.Appointments.Remove(appointment);

                    del = false;
                }

            }else {

                if(attend == true )
                {  
                    CalendarInlineEvent calendarInlineEvent = new CalendarInlineEvent();
                    calendarInlineEvent.StartTime = e.DateTime.Date.AddHours(1);
                    calendarInlineEvent.EndTime = e.DateTime.Date.AddHours(2);
                    calendarInlineEvent.Subject = "I attend";
                    calendarInlineEvent.Color = Color.FromHex("#FF0000FF");
                    viewmodel.Appointments.Add(calendarInlineEvent);
                    attend = false;

                }else if (paid == true)
                {
                    CalendarInlineEvent calendarInlineEvent = new CalendarInlineEvent();
                    calendarInlineEvent.StartTime = e.DateTime.Date.AddHours(1);
                    calendarInlineEvent.EndTime = e.DateTime.Date.AddHours(2);
                    calendarInlineEvent.Subject = "I paid";

                    calendarInlineEvent.Color = Color.FromHex("#FF008000");
                    viewmodel.Appointments.Add(calendarInlineEvent);
                    paid = false;

                }






            }




        }

           

            

        }

       
    
      
}