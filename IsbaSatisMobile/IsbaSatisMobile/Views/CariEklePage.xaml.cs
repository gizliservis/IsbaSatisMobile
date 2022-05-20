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
    public partial class CariEklePage : ContentPage
    {
        public CariEklePage()
        {
            InitializeComponent();
        }
        private void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                Cari stk = new Cari
                {
                 
                    CariAdi = txtCariAdi.Text,
                    CariKodu = txtCariKodu.Text,
                    FaturaUnvani = txtFaturaUnvani.Text,
                    CariGrubu = txtCariGrubu.Text,
                    CariTuru = txtCariTuru.Text,
                    Il = txtIl.Text,
                    Ilce =txtIlce.Text,
                    Adres = txtAdres.Text,
                };
                if (stk.CariAdi != null && stk.CariKodu != null && stk.FaturaUnvani != null)
                {
                    ServiceManager manager = new ServiceManager();
                    manager.Cariekle(stk);
                    DisplayAlert("Eklendi", "Başarılı Bir Şekilde \n Ekleme İşlemi gerçekleştirildi.", "OK");
                    txtCariAdi.Text = null;
                    txtCariKodu.Text = null;
                    txtFaturaUnvani.Text = null;
                    txtCariGrubu.Text = null;
                    txtCariTuru.Text = null;
                    txtIl.Text = null;
                    txtIlce.Text = null;
                    txtAdres.Text = null;

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