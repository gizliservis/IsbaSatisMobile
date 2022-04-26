using IsbaSatisMobile.Models;
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
    public partial class StokDetayPage : ContentPage
    {
        int _id;
        public StokDetayPage(Stok stok)
        {
            InitializeComponent();
            _id = stok.Id;
            txtStokAdi.Text = stok.StokAdi;
            txtStokKodu.Text = stok.StokKodu;
            txtBarkod.Text = stok.Barkod;
            txtBirimi.Text = stok.Birimi;
            txtSatisF.Text = stok.SatisFiyati1.ToString();
            txtAlisF.Text = stok.AlisFiyati1.ToString();
            txtSatisKdv.Text = stok.SatisKdv.ToString();
            txtAlisKdv.Text = stok.AlisKdv.ToString();
            switcDurumu.On = stok.Durumu;

        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                Stok stok = new Stok();
                stok.Id = _id;
                stok.StokAdi = txtStokAdi.Text;
                stok.StokKodu = txtStokKodu.Text;
                stok.Barkod = txtBarkod.Text;
                stok.Birimi = txtBirimi.Text;
                stok.SatisFiyati1 = Convert.ToDecimal(txtSatisF.Text != null);
                stok.AlisFiyati1 = Convert.ToDecimal(txtAlisF.Text != null);
                stok.SatisKdv = Convert.ToInt32(txtSatisKdv.Text != null);
                stok.AlisKdv = Convert.ToInt32(txtAlisKdv.Text != null);


                ServiceManager manager = new ServiceManager();
                manager.Guncelle(stok);
                DisplayAlert("Başarılı", "Güncelleme Başarılı", "Ok");
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {

                DisplayAlert("Başarısız", ex.Message, "Ok");
            }
           
        }
    }
}