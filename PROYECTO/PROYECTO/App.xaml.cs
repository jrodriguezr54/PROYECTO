using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PROYECTO.controler;

namespace PROYECTO
{
    public partial class App : Application
    {
        static emplecontroler _connection;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static emplecontroler Database
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new emplecontroler(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Agua.db3"));
                }
                return _connection;
            }
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
