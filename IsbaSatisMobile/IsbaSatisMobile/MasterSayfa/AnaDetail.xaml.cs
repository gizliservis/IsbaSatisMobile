using IsbaSatisMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IsbaSatisMobile.MasterSayfa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnaDetail : ContentPage
    {
        public AnaDetail()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new StoklarPage());
        }
    }
}