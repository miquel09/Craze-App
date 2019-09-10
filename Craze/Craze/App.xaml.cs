using Craze.Data.Abstract;
using Craze.Data.Sqlite;
using Craze.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Craze
{
    public partial class App : Application
    {
        static IAnimalRepository database;

        public static IAnimalRepository Database {
            get {
                if (database == null) {
                    database = new SqliteAnimalRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AnimalSQLite.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            NavigationPage navPage = new NavigationPage(new LoginPage());
            navPage.BarBackgroundColor = new Color(250.0 / 255.0, 180.0 / 255.0, 200.0 / 255.0);
            navPage.BackgroundColor = new Color(190.0 / 255, 200.0 / 255, 230.0 / 255);

            MainPage = navPage;
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
