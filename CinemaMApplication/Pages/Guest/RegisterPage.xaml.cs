using CinemaMApplication.CinemaAPI;
using CinemaMApplication.Service;

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaMApplication.Pages.Guest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        UserRequest user;
        CinemaApi cinemaApi;

        public RegisterPage()
        {
            InitializeComponent();
            cinemaApi = new CinemaApi();
        }

        async void SignupValidation_ButtonClicked(object send, EventArgs e)
        {
            
            user = new UserRequest();
           
            user.username = userNameEntry.Text;
            user.firstName = firstNameEntry.Text;
            user.lastName = lastNameEntry.Text;
            user.email = emailEntry.Text;
            user.phone = phoneEntry.Text;
            user.password = passwordEntry.Text;
            user.lastModified_18118032 = DateTime.Now;
            user.roleID = 2;
            if (passwordEntry.Text.Equals(confirmpasswordEntry.Text))
            {
                cinemaApi.RegisterUser(user);
                await Navigation.PushAsync(new LoginPage());
            }else
            {
                warningLabel.IsVisible = true;
            }
        }

      
    }
}