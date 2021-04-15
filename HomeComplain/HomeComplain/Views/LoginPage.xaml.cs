using HomeComplain.Models;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void RegisterUserCommand(object s, EventArgs e)
        {
            await this.Navigation.PushAsync(new CreateUserPage());
        }

        async void onlogin(object s, EventArgs e)
        {
            try
            {
                //null or blank space check
                if (!string.IsNullOrWhiteSpace(loginFullName.Text) && !string.IsNullOrWhiteSpace(loginPassword.Text))
                {
                    //create UserInfo instance and call athentiication function
                    UserDetail userDetail = App.Database.GetUserAthentication(loginFullName.Text, loginPassword.Text);

                    if (userDetail != null)
                    {
                        if (loginFullName.Text != userDetail.FullName && loginPassword.Text != userDetail.Password)
                        {
                           
                            await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Registrtion", "Login Success ...", "OK");
                            //App._CurrentUser = userDetail;
                            //App._UserID = userDetail.UserID;
                            App._currentUser = userDetail;
                            App.Current.MainPage = new NavigationPage(new MainComplaintPage());
                        }
                    }
                    else
                    {
                        await DisplayAlert("Login", "Login failed .. try again ", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Please Enter Email and Password.", "OK");
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
            }           

        }


    }
}