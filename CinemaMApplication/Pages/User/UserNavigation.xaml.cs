using CinemaMApplication.Pages.Admin;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaMApplication.Pages.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class UserNavigation : MasterDetailPage
    {
        public UserNavigation()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as String;
            if (selectedItem == "Film Catalog")
            {
                Detail = new NavigationPage(new UserFilmCatalog());
            }

            if (selectedItem == "Reservations")
            {
                Detail = new NavigationPage(new UserReservations());
            }
        }
    }
}