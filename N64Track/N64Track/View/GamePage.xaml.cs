using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace N64Track
{
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Game game = (Game)this.BindingContext;
        }

        void EditClicked(object sender, EventArgs e)
        {
            var gamePage = new GameEditPage();
            var game = (Game)this.BindingContext;
            gamePage.BindingContext = game;
            Navigation.PushAsync(gamePage);
        }

        void ReturnClicked(object sender, EventArgs e)
        {
            //this.Navigation.PopAsync();
            var gamePage = new MainPage();
            Navigation.PushAsync(gamePage);
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
