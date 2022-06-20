using CinemaMApplication.CinemaAPI;
using CinemaMApplication.Service;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaMApplication.Pages.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserReservations : ContentPage
    {
        CinemaApi cinemaApi;
        public ObservableCollection<ReservationResponse> Items { get; set; }

        public UserReservations()
        {
            InitializeComponent();
            cinemaApi = new CinemaApi();
            getReservations();
        }

        private async void getReservations()
        {
            int userId = LoggedInUser.loggedInUser.userID;
            var response =await cinemaApi.getReservationByUserId(userId);
          
            Items = new ObservableCollection<ReservationResponse>(response.reservations);
            MyListView.ItemsSource = Items;
        }

        async void Delete_Reservation(object sender, EventArgs e)
        {
            Button _myButton = (Button)sender;
            string value = _myButton.CommandParameter.ToString();
            int id = int.Parse(value);
       
            cinemaApi.deleteReservation(id);
            await DisplayAlert("Successfully removed reservation", "", "Ok");
            await Navigation.PushAsync(new UserReservations());
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }


    }
}
