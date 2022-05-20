using IsbaSatisMobile.MasterSayfa;
using IsbaSatisMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IsbaSatisMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FaturaKaydetPage();
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
