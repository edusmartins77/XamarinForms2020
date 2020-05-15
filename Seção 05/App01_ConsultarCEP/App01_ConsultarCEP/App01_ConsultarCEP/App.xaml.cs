using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ConsultarCEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new App01_ConsultarCEP.MainPage();
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
