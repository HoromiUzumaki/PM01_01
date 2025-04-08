using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Happy_tooth_Mobile
{
    public partial class App : Application
    {
        public static DatabaseContext Database { get; private set; }
        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "happytooth.db3");

            Database = new DatabaseContext(dbPath);

            MainPage = new NavigationPage(new MainPage());
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
