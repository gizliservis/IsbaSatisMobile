using IsbaSatisMobile.Models;
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
    public partial class StokDetayPage : ContentPage
    {
        public StokDetayPage(Stok stok)
        {
            InitializeComponent();
            txtStokAdi.Text = stok.StokAdi;
            txtStokKodu.Text = stok.StokKodu;
            txtBarkod.Text=stok.Barkod;
            txtBirimi.Text=stok.Birimi; 
            txtSatisF.Text=stok.SatisFiyati1.ToString();
            txtAlisF.Text=stok.AlisFiyati1.ToString();
            txtSatisKdv.Text = stok.SatisKdv.ToString();
            txtAlisKdv.Text=stok.AlisKdv.ToString();
            switcDurumu.On = stok.Durumu;

        }
    }
}