using CinemaMApplication.CinemaAPI;
using CinemaMApplication.Service;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaMApplication.Pages.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmCatalog : ContentPage
    {
        public ObservableCollection<FilmResponse> Items { get; set; }
        CinemaApi cinemaApi;
       
       public FilmCatalog()
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

        async void deleteFilmFromCatalog(object sender, EventArgs e)
        {
            Button _myButton = (Button)sender;
            string value = _myButton.CommandParameter.ToString();
            int id = int.Parse(value); 
            
               cinemaApi.deleteFilm(id);
               await Navigation.PushAsync(new FilmCatalog());
            
           
           
        }
        async void edit_film(object sender, EventArgs e)
        {
            Button _myButton = (Button)sender;
            string value = _myButton.CommandParameter.ToString();
            int id = int.Parse(value);
            (App.Current as App).filmId = id;
            await Navigation.PushAsync(new Edit_Film());
        }
   }
}
