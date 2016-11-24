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
            var item = (Button)sender;
            Data.JsonReaderN64 js = new Data.JsonReaderN64();
           js.getData("N64Track.Data.n64jap.json");
        }

        void JsonPalClicked(object sender, EventArgs args)
        {
            var item = (Button)sender;
            Data.JsonReaderN64 js = new Data.JsonReaderN64();
            js.getData("N64Track.Data.n64pal.json");
        }
        void DBAllClicked(object sender, EventArgs args)
        {
            App.Database.Generate();
        }

        void ResetClicked(object sender, EventArgs args)
        {
            App.Database.Reset();
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
