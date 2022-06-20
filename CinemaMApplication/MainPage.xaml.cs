using CinemaMApplication.Pages.Admin;
using CinemaMApplication.Pages.Guest;
using CinemaMApplication.Pages.User;
using CinemaMApplication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CinemaMApplication
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
     
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
            var selectedItem = e.SelectedItem as String;
           
            if (selectedItem == "Login")
            {
                Detail = new NavigationPage(new LoginPage());
               
            }
            if (selectedItem == "Register")
            {
                Detail = new NavigationPage(new RegisterPage());
            }
        }
    }
}
