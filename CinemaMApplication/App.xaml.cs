using CinemaMApplication.Pages.Admin;
using CinemaMApplication.Pages.User;
using CinemaMApplication.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaMApplication
{
    public partial class App : Application
    {
        public int filmId { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
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
