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
    public partial class FaturaKaydetPage : ContentPage
    {
        readonly IList<Stok> stoks = new ObservableCollection<Stok>();
        readonly ServiceManager manager = new ServiceManager();
        readonly IList<Stok>Estoks=new ObservableCollection<Stok>();
        public FaturaKaydetPage()
        {
            InitializeComponent();
             BindingContext = stoks;
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
                this.IsBusy = false;
            }
        }
    }
}