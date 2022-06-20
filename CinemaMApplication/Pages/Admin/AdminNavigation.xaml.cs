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
    public partial class AdminNavigation : MasterDetailPage
    {
        public AdminNavigation()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as String;
            if (selectedItem == "Add new film")
            {
                Detail = new NavigationPage(new AddNewFilm());
            }
            
            if (selectedItem == "All films")
            {
                Detail = new NavigationPage(new FilmCatalog());
            }
             if(selectedItem == "Logout")
            {
                LoggedInUser.loggedInUser = null;
                Detail = new NavigationPage(new MainPage());
            }

        }
    }
}
