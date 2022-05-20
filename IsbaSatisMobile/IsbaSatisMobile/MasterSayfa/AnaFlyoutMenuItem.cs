using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisMobile.MasterSayfa
{
    public class AnaFlyoutMenuItem
    {
        public AnaFlyoutMenuItem()
        {
            TargetType = typeof(AnaFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}