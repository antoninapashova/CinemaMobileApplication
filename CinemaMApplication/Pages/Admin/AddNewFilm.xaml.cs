using CinemaMApplication.CinemaAPI;
using CinemaMApplication.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaMApplication.Pages.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewFilm : ContentPage
    {

        CinemaApi cinemaApi;
        FilmRequest filmEntity;
        public AddNewFilm()
        { 
            cinemaApi = new CinemaApi(); 
            InitializeComponent();
            getGenres();
            getCinemaRoom();
        }

        async void AddNewFilm_ButtonClicked(object sender, EventArgs e)
        {
            filmEntity = new FilmRequest();
            filmEntity.name = filmNameEntry.Text;
            filmEntity.description = descriptionEntry.Text;
            filmEntity.genreID = genrePicker.SelectedIndex+1;

           filmEntity.ticketPrice = Double.Parse(ticketPriceEntry.Text);
            filmEntity.duration = durationEntry.Text;
            filmEntity.start = startDatePicker.Date + timePicker.Time;

            filmEntity.cinemaRoomID = cinemaRoomPicker.SelectedIndex+1;
            filmEntity.lastModified_18118032 = DateTime.Now;

            cinemaApi.addNewFilm(filmEntity);
            await  DisplayAlert("Successfully addded film", "Ok", "Cansel");

            await Navigation.PushAsync(new FilmCatalog());

        }

        async void getGenres()
        {
            var genres = await cinemaApi.getAllGenres();
            genrePicker.ItemsSource = genres;
            genrePicker.ItemDisplayBinding = new Binding("name");
        }

        async void getCinemaRoom()
        {
            var cinemaRooms = await cinemaApi.getAllCinemaRooms();
            cinemaRoomPicker.ItemsSource = cinemaRooms;
            cinemaRoomPicker.ItemDisplayBinding = new Binding("number");
        }
    }
}