using HomeComplain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeComplain.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainComplaintPage : ContentPage
    {
        public ObservableCollection<ComplaintDetail> ComplaintModelPairs { get; set; }
        public MainComplaintPage()
        {
            InitializeComponent();
            ComplaintModelPairs = new ObservableCollection<ComplaintDetail>();
            try
            {
                complaintDataList.ItemsSource = App.Database.GetComplaintAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
            if(App._currentUser != null)
            {
                CurrentLoginUser.IsVisible = true;
                logoutText.IsVisible = true;
                boxLine.IsVisible = true;
                CurrentLoginUser.Text = "User : " + App._currentUser.FullName;
            }
            else
            {
                boxLine.IsVisible = false;
                CurrentLoginUser.IsVisible = false;
                logoutText.IsVisible = false;
            }
            
        }

        async void ONLoginBtnClicked(object sender, EventArgs args)
        {
            try { 


                if (App._currentUser != null && App._currentUser.UserID > -1)
                {
                    await DisplayAlert("Message", App._currentUser.FullName + "  Logedin. ", "OK");
                }
                else
                {
                    await this.Navigation.PushAsync(new LoginPage());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async void ONSearchBtnClicked(object sender, EventArgs args)
        {
            if(App._currentUser != null && App._currentUser.UserID > -1)
            {
                await this.Navigation.PushAsync(new MakeComplaint());
            }
            else
            {
                await DisplayAlert("Error", "You are required to login .. Please login. ", "OK");
            }     
        }

        private void UserLogoutCommand(object s, EventArgs e)
        {
            App._currentUser = null;
            App.Current.MainPage = new NavigationPage(new MainComplaintPage());
        }


    }
}