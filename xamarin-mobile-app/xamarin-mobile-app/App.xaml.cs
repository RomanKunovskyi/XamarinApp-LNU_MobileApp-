using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_mobile_app.Views;

namespace xamarin_mobile_app
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
