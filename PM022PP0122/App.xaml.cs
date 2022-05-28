using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM022PP0122.Controller;
using PM022PP0122.Views;
using System.IO;

namespace PM022PP0122
{
    public partial class App : Application
    {
        static DataBase db;

        public static DataBase DBase
        {
            get
            {
                if(db == null)
                {
                    String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Emple.db3");
                    db = new DataBase(FolderPath);
                }

                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new PagePrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
