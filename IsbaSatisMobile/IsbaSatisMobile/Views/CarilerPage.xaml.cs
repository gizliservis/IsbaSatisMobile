using IsbaSatisMobile.Models;
using IsbaSatisMobile.Provider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IsbaSatisMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarilerPage : ContentPage
    {

        readonly ServiceManager manager = new ServiceManager();
        readonly IList<Cari> stoks = new ObservableCollection<Cari>();
        public CarilerPage()
        {
            InitializeComponent();
            BindingContext = stoks;
            CariData();
        }
        private async void CariData()
        {
            this.IsBusy = true;
            try
            {
                stoks.Clear();
                await Task.Delay(2000);
                var colection = await manager.CariListele();
                foreach (Cari item in colection)
                    stoks.Add(item);

                // lstStok.BindingContext = colection;
            }
            finally
            {
                this.IsBusy = false;
            }
        }
        private void lstStok_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //ListView lstView = (ListView)sender;
            //if (e.SelectedItem != null)
            //{
            //    var selectedStok = (Stok)e.SelectedItem;
            //    Navigation.PushModalAsync(new StokDetayPage(selectedStok));
            //}
            //lstView.SelectedItem = null;

        }
        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var selectedStok = (Cari)menuItem.CommandParameter;
            var isOk = await DisplayAlert("", "Silmek İstediğinize Eminmisiniz", "Evet", "Hayır");

            if (isOk)
            {
                manager.CariSil(selectedStok);
                stoks.Remove(selectedStok);
                CariData();
            }
        }
        private void Yenile_Clicked(object sender, EventArgs e)
        {
            CariData();
        }

        private void ekle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CariEklePage());
            CariData();
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstStok.ItemsSource = stoks.Where(c => c.CariAdi.StartsWith(e.NewTextValue) || c.CariKodu.StartsWith(e.NewTextValue));
        }
    }
}