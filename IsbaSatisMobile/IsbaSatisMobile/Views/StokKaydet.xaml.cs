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
                if (stk.StokAdi!=null && stk.StokKodu!=null && stk.Barkod!=null)
                {
                    ServiceManager manager = new ServiceManager();
                    manager.ekle(stk);
                    DisplayAlert("Eklendi", "Başarılı Bir Şekilde \n Ekleme İşlemi gerçekleştirildi.", "OK");
                    txtAlisF.Text = null;
                    txtAlisKdv.Text = null;
                    txtSatisF.Text = null;
                    txtSatisKdv.Text = null;
                    txtBirimi.Text = null;
                    txtBarkod.Text = null;
                    txtStokKodu.Text = null;
                    txtStokAdi.Text = null;

                    Navigation.PopModalAsync();
                }
                else
                {
                    DisplayAlert("Eklenemedi!!!", "Lütfen Kontrol Ediniz.", "OK");
                }
              
           
            }
            catch (Exception)
            {
                DisplayAlert("Eklenemedi", "Başarılı Bir Şekilde \n Ekleme İşlemi Gerçekleştirilemedi.", "OK");
                throw;
            }
     

        }
    }
}