using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace N64Track
{
    public partial class MainPage : ContentPage
    {
        
        List<Game> FilterList;

        //MVVM Model for app
        GameViewModel GVM;

        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            //Load list of Games from DB
            //public List<Game> GameList = App.Database.GetGames().ToList();
            //GVM = new GameViewModel(GameList);

           //load the list into the view model
           GVM = new GameViewModel(App.Database.GetGames().ToList());
            FilterList = GVM.Games.ToList();
            // GVM = new GameViewModel();
            //set source to model
            GameListView.ItemsSource = GVM.Games;
        }

        void GameSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var gameItem = (Game)e.SelectedItem;
            var gamePage = new GamePage();
            gamePage.BindingContext = gameItem;
            Debug.WriteLine("setting view to game = " + gameItem.Name);
            Navigation.PushAsync(gamePage);
        }

        void AddGameClicked(object sender, EventArgs e)
        {
            var gamePage = new GameEditPage();
            var game = new Game();
            gamePage.BindingContext = game;
            Navigation.PushAsync(gamePage);
        }
        
        void FilterClicked(object sender, EventArgs e)
        {
            string filter = FilterText.Text;

            if(filter == "Show All Games")
            {
                FilterList = GVM.Games.ToList();
             //   var filtered = FilterList.Any(o => o.Publisher == "Nintendo");
          //      GameListView.ItemsSource = filtered();
                FilterText.Text = "Show Nintendo Games";
            }
            else if (filter == "Show Nintendo Games")
            {
                FilterList = GVM.Games.ToList();
                // var filtered = FilterList.Where(o => o.wineType == PkrType.Items[PkrType.SelectedIndex]).ToList();
                GameListView.ItemsSource = FilterList;
                FilterText.Text = "Show Action Games";
            }
            else
            {
                FilterText.Text = "Show All Games";
                GameListView.ItemsSource = GVM.Games;
            }
        }

        //footer methods
        async void FootNavGameClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void FootNavAboutClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}

