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
    public partial class StoklarPage : ContentPage
    {
        readonly ServiceManager manager = new ServiceManager();
        readonly IList<Stok>stoks=new ObservableCollection<Stok>();
        public StoklarPage()
        {
            BindingContext = stoks;
            InitializeComponent();
            StokData();
        }

        private async void StokData()
        {
            this.IsBusy = true;
            try
            {
                stoks.Clear();
                await Task.Delay(2000);
                var colection = await manager.StokListele();
                foreach (Stok item in colection)
                    stoks.Add(item);

               // lstStok.BindingContext = colection;
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

        private void lstStok_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lstView= (ListView)sender;
            if (e.SelectedItem!=null)
            {
                var selectedStok = (Stok)e.SelectedItem;
                Navigation.PushModalAsync(new StokDetayPage(selectedStok));
            }
            lstView.SelectedItem = null;
   
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var selectedStok = (Stok)menuItem.CommandParameter;
            var isOk = await DisplayAlert("", "Silmek İstediğinize Eminmisiniz", "Evet", "Hayır");

            if (isOk)
            {
                manager.Sil(selectedStok);
                stoks.Remove(selectedStok);

            }
        }
    }
}