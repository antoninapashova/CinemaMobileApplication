using CinemaMApplication.CinemaAPI;
using CinemaMApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaMApplication.Pages.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edit_Film : ContentPage
    {
        CinemaApi cinemaApi;
        int selectedFilmId { get; set; }
        public Edit_Film()
        {
            cinemaApi = new CinemaApi();
            getFilmForEditing();
            InitializeComponent();
        }


        async void getFilmForEditing()
        {
            selectedFilmId = (App.Current as App).filmId;
            var filmforEdit = await cinemaApi.getFilmById(selectedFilmId);

            var genre = await cinemaApi.getAllGenres();
            genrePicker.ItemsSource = genre;

            genrePicker.ItemDisplayBinding = new Binding("name");
            var dateAndTime = filmforEdit.start;

            var date = dateAndTime.ToShortDateString();
            string hour = dateAndTime.ToString("HH");
            string minute = dateAndTime.ToString("mm");
            string sencond = dateAndTime.ToString("ss");
            int year = dateAndTime.Year;
            int month = dateAndTime.Month;
            int day = dateAndTime.Day;

            timePicker.Time = new TimeSpan(Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(sencond));
            startDatePicker.Date = new DateTime(year, month, day);

            var cinemaRooms = await cinemaApi.getAllCinemaRooms();
            cinemaRoomPicker.ItemsSource = cinemaRooms;
            cinemaRoomPicker.ItemDisplayBinding = new Binding("number");

            BindingContext = filmforEdit;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
           var filmEntity = new FilmRequest();
            filmEntity.name = filmNameEntry.Text;
            filmEntity.description = descriptionEntry.Text;
           filmEntity.genreID = genrePicker.SelectedIndex + 1;

           filmEntity.ticketPrice = Double.Parse(ticketPriceEntry.Text);
           filmEntity.duration = durationEntry.Text;
          filmEntity.start = startDatePicker.Date + timePicker.Time;

          filmEntity.cinemaRoomID = cinemaRoomPicker.SelectedIndex + 1;
          filmEntity.lastModified_18118032 = DateTime.Now;

           cinemaApi.editFilm(selectedFilmId, filmEntity);
            await DisplayAlert("Edit is successfull", "", "Ok", "Cancel");
            await Navigation.PushAsync(new FilmCatalog());
        }
    }
}