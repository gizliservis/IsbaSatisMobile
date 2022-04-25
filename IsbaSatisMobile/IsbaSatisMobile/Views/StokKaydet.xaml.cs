using IsbaSatisMobile.Models;
using IsbaSatisMobile.Provider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IsbaSatisMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StokKaydet : ContentPage
    {
        public StokKaydet()
        {
            InitializeComponent();

        }



        private void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                Stok stk = new Stok
                {
                    Durumu = switcDurumu.On,
                    StokAdi = txtStokAdi.Text,
                    StokKodu = txtStokKodu.Text,
                    Barkod = txtBarkod.Text,
                    SatisFiyati1 = Convert.ToDecimal(txtSatisF.Text),
                    AlisFiyati1 = Convert.ToDecimal(txtAlisF.Text),
                    AlisKdv = Convert.ToInt32(txtAlisKdv.Text),
                    SatisKdv = Convert.ToInt32(txtSatisKdv.Text),
                    Birimi = txtBirimi.Text,
                };
                ServiceManager manager = new ServiceManager();
                manager.ekle(stk);
                DisplayAlert("Eklendi", "Başarılı Bir Şekilde \n Ekleme İşlemi gerçekleştirildi.", "OK");
                Navigation.PopModalAsync();
            }
            catch (Exception)
            {
                DisplayAlert("Eklenemedi", "Başarılı Bir Şekilde \n Ekleme İşlemi Gerçekleştirilemedi.", "OK");
                throw;
            }
     

        }
    }
}