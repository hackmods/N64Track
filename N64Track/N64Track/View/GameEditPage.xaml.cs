using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace N64Track
{
    public partial class GameEditPage : ContentPage
    {
        Game original = new Game();
        public GameEditPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            original = (Game)this.BindingContext;
        }

        async void SaveClicked(object sender, EventArgs e)
        {
            //get object from page
            var game = (Game)BindingContext;

            //insert in DB, get the returend object
            game = App.GCL.UpdateGame(game);

            //load page with object
            var gamePage = new GamePage();
            gamePage.BindingContext = game;
            await Navigation.PushAsync(gamePage);
        }

        void DeleteClicked(object sender, EventArgs e)
        {
            var gameItem = (Game)BindingContext;
            App.GCL.RemoveGame(gameItem);
            Navigation.PushAsync(new MainPage());
        }

        void CancelClicked(object sender, EventArgs e)
        {
            // this.Navigation.PopAsync();
            if (original.ID == 0)
            {
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                Game old = App.Database.GetGame(original.ID);
                var gamePage = new GamePage();
                gamePage.BindingContext = App.Database.GetGame(original.ID);
                Navigation.PushAsync(gamePage);
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