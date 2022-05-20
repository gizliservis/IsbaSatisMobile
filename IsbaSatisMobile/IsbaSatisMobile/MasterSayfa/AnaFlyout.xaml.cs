using IsbaSatisMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IsbaSatisMobile.MasterSayfa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnaFlyout : ContentPage
    {
        public ListView ListView;
       public StoklarPage stk=new StoklarPage();
        public AnaFlyout()
        {
            InitializeComponent();

            BindingContext = new AnaFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class AnaFlyoutViewModel : INotifyPropertyChanged
        {
            public List<AnaFlyoutMenuItem> MenuItems { get; set; }

            public AnaFlyoutViewModel()
            {
                MenuItems = new List<AnaFlyoutMenuItem>(new[]
                {
                    new AnaFlyoutMenuItem { Id = 0, Title = "Stoklar Listesi",TargetType=typeof(StoklarPage)},
                    new AnaFlyoutMenuItem { Id = 1, Title = "Cari Listesi",TargetType=typeof(CarilerPage)},
                    //new AnaFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    //new AnaFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    //new AnaFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}