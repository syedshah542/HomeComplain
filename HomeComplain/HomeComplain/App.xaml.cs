using HomeComplain.Data;
using HomeComplain.Models;
using HomeComplain.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeComplain
{
    public partial class App : Application
    {
        static SQLiteComplaintDBHelper TicketDB;
        public static UserDetail _currentUser { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainComplaintPage());
            //MainPage = new MainComplaintPage();
        }

        internal static SQLiteComplaintDBHelper Database
        {
            get
            {
                if (TicketDB == null)
                {
                    TicketDB = new SQLiteComplaintDBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "complaintBD.db3"));
                }
                return TicketDB;
            }
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
