using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace N64Track
{
    public partial class App : Application
    {
        static N64Database database;
        static GameCollectionLib gcl;
        public App()
        {
            InitializeComponent();

            //check if db exists
            Database.CheckDBLoad();

            //   MainPage = new N64Track.MainPage();
            var nav = new NavigationPage(new MainPage());
            MainPage = nav;
        }

        public static N64Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new N64Database();
                }
                return database;
            }
        }

        public static GameCollectionLib GCL
        {
            //mcl = MyCellarLib
            get
            {
                if (gcl == null)
                {
                    gcl = new GameCollectionLib();
                }
                return gcl;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
