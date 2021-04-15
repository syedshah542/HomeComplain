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
    public partial class CreateUserPage : ContentPage
    {
        public CreateUserPage()
        {
            InitializeComponent();
        }


        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entryEmail.Text) && !string.IsNullOrWhiteSpace(entryPassword.Text))
            {
                int r = App.Database.SaveOrUpdateUser(new Models.UserDetail
                {
                    FullName = entryName.Text,
                    EmailId = entryEmail.Text,
                    Password = entryPassword.Text,
                    Contact = entryContact.Text
                });

                if (r > -1)
                {

                }
                entryName.Text = entryPassword.Text = entryContact.Text = string.Empty;
                //listView.ItemsSource = await App.Database.GetPeopleAsync();

                //save message
                await DisplayAlert("Alert", "Account created successfully.", "OK");

                //open login Page
                // await Navigation.PushAsync(new UserLogin());
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }


    }
}