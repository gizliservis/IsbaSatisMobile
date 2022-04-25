using IsbaSatisMobile.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IsbaSatisMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoklarPage : ContentPage
    {
        readonly ServiceManager manager = new ServiceManager();
        public StoklarPage()
        {
            InitializeComponent();
            StokData();
        }

        private async void StokData()
        {
            this.IsBusy = true;
            try
            {
                await Task.Delay(5000);
                var colection = await manager.StokListele();
                lstStok.BindingContext = colection;
            }
            finally
            {
                this.IsBusy=false;
            }
        }

        private void Kaydet_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new StokKaydet());
        }
        private void Refresh_Cliced(object sender, EventArgs e)
        {
            StokData();
        }

       
    }
}