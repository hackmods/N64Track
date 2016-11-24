using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace N64Track
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        void JsonJapClicked(object sender, EventArgs args)
        {
            StartActivity();
            var item = (Button)sender;
            Data.JsonReaderN64 js = new Data.JsonReaderN64();
           js.getData("N64Track.Data.n64jap.json");
            EndActivity();
        }

        void JsonPalClicked(object sender, EventArgs args)
        {
            StartActivity();
            var item = (Button)sender;
            Data.JsonReaderN64 js = new Data.JsonReaderN64();
            js.getData("N64Track.Data.n64pal.json");
            EndActivity();
        }
        void DBAllClicked(object sender, EventArgs args)
        {
            StartActivity();
            App.Database.Generate();
            EndActivity();
        }

        void DBStartClicked(object sender, EventArgs args)
        {
            StartActivity();
            App.Database.ReGenerate();
            EndActivity();
        }

        void ResetClicked(object sender, EventArgs args)
        {
            StartActivity();
            App.Database.Reset();
            EndActivity();
        }
        
        void StartActivity()
        {
            this.GameScrollView.Opacity = 0.5;
            activityIndicator.IsVisible = true;
            activityIndicator.IsRunning = true;
        }

        void EndActivity()
        {
            activityIndicator.IsVisible = false;
            activityIndicator.IsRunning = false;
            this.GameScrollView.Opacity = 1;
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
