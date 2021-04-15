using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeComplain.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeComplaint : ContentPage
    {
        public MakeComplaint()
        {
            InitializeComponent();

            //initial value of date
            cmpDate.SetValue(DatePicker.MinimumDateProperty, DateTime.Now);
            cmpDate.SetValue(DatePicker.MaximumDateProperty, DateTime.Now.AddDays(180));
        }


        async void OnCreateComplaintClicked(object sender, EventArgs args)
        {
            //fields validation
            if (await ValidateEntriesAsync())
            {
                //Creating new ComplaintInfo object and call save method
                App.Database.SaveNewComplaintOrUpdate(new Models.ComplaintDetail
                {
                    ComplaintTitle = cmpTitle.Text,
                    ComplatintType = cmpType.SelectedItem.ToString(),
                    ComplaintDate = cmpDate.Date,
                    ComplaintDiscription = cmpDiscription.Text,
                    ComplaintSolution = cmpSolution.Text,
                    ComplaintStatus = "Pending",
                    Complaintner = App._currentUser.FullName,
                    UserID = App._currentUser.UserID
                });


                //empty entries
                cmpDate.SetValue(DatePicker.MinimumDateProperty, DateTime.Now);
                cmpDate.SetValue(DatePicker.MaximumDateProperty, DateTime.Now.AddDays(180));
                cmpDiscription.Text = cmpSolution.Text = string.Empty;
                

                //message
                await DisplayAlert("Info", "Complaint Submited Successfully..", "OK");

                //back to Main Page
                await Application.Current.MainPage.Navigation.PopAsync();
            }

        }

        //Entries validation 
        private async Task<bool> ValidateEntriesAsync()
        {
            bool entryStatus = true;
            if (string.IsNullOrWhiteSpace(cmpTitle.Text))
            {
                entryStatus = false;
            }

            if (string.IsNullOrWhiteSpace(cmpType.SelectedItem.ToString()))
            {
                entryStatus = false;
            }

            if (string.IsNullOrWhiteSpace(cmpDiscription.Text))
            {
                entryStatus = false;
            }
            if (string.IsNullOrWhiteSpace(cmpSolution.Text))
            {
                entryStatus = false;
            }


            if (!entryStatus)
            {
                await DisplayAlert("Error", "Fill empty fields.", "OK");
            }

            return entryStatus;
        }


    }
}