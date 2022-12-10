using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;


namespace Smartfit_APP.ViewModels
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private CalendarEventCollection appointments;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> meetingSubjectCollection;
        public CalendarEventCollection Appointments
        {
            get
            {
                return this.appointments;
            }

            set
            {
                this.appointments = value;
                this.OnPropertyChanged("Appointments");
            }
        }
        public CalendarViewModel()
        {
            this.Appointments = new CalendarEventCollection();
            this.AddAppointmentDetails();
           // this.AddAppointments();
        }
        private void AddAppointmentDetails()
        {
            meetingSubjectCollection = new ObservableCollection<string>();
            meetingSubjectCollection.Add("I attended");
           
        }
      
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
