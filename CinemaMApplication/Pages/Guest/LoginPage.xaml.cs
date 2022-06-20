using CinemaMApplication.CinemaAPI;
using CinemaMApplication.Pages.Admin;
using CinemaMApplication.Pages.User;
using CinemaMApplication.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaMApplication.Pages.Guest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        CinemaApi cinemaApi;
        
        public LoginPage()
        {
            InitializeComponent();
            cinemaApi = new CinemaApi();
        }

        public async void LoginButton(object sender, EventArgs e)
        {
           
            var user = await cinemaApi.checkLogin(emailEntry.Text, passwordEntry.Text);
            if (user != null)
            {
                await DisplayAlert("Login Successfull", "Username and Password are correct", "Okay", "Cancel");
            

                LoggedInUser.loggedInUser = user;
                
                if (user.roleID == 1)
                {
                    App.Current.MainPage = new NavigationPage(new AdminNavigation());
                    
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new UserNavigation());
                }
                
            }

            else if (emailEntry.Text == null && passwordEntry.Text == null)
            {
                await DisplayAlert("Login failed", "Enter your Email and Password before login", "Okay", "Cancel");
            }
            else
            {
                await DisplayAlert("Login failed", "Email or Password is incorrect or not exists", "Okay", "Cancel");
            }
            }
        }
 }
