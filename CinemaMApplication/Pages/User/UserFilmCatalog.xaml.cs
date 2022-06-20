
using CinemaMApplication.CinemaAPI;
using CinemaMApplication.Service;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaMApplication.Pages.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserFilmCatalog : ContentPage
    {
        public ObservableCollection<FilmResponse> Items { get; set; }
        CinemaApi cinemaApi;
        
        public UserFilmCatalog()
        {
            InitializeComponent();
            cinemaApi = new CinemaApi();
            showAllFilms();
        }

        async void showAllFilms()
        {
            var films = await cinemaApi.getAllFilms();
            Items = new ObservableCollection<FilmResponse>(films);
            MyListView.ItemsSource = Items;
        }
        async void Searh_Film(object sender, EventArgs e)
        {
            var films = await cinemaApi.getAllFilms();
            var filmRecords = films.Where(c => c.name.Contains(searchByName.Text));
            Items = new ObservableCollection<FilmResponse>(filmRecords);
            MyListView.ItemsSource = Items;
        }
   

        async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            ReservationRequest request = new ReservationRequest();
            request.userID = LoggedInUser.loggedInUser.userID;
           
            var selectedFilm = e.SelectedItem as FilmResponse;

            if (selectedFilm != null)
            {
                request.filmID = selectedFilm.filmID;
            }
            request.lastModified_18118032 = DateTime.Now;
            string count = await DisplayPromptAsync("How many tickets want to reserve?","Count", "Ok", "Cancel"); ;
            request.numberOfTickets = int.Parse(count);
            await DisplayAlert("Reservation", "Do you want to make the reservation?", "Ok", "Cancel");
            cinemaApi.makeReservation(request);

       }


    }
}
