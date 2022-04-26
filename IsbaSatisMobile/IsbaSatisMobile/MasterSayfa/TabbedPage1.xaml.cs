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
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            //var tabbedpage = new ScrollableTabbedPage();
            Children.Add(new StoklarPage());
            Children.Add(new StokKaydet());
            Children.Add(new StokKaydet());
            Children.Add(new StokKaydet());
            Children.Add(new StokKaydet());
            Children.Add(new StokKaydet());
            
        }
    }
}