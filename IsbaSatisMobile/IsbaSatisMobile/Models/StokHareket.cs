using System;
using System.Collections.Generic;
using System.Text;

namespace IsbaSatisMobile.Models
{
    public class StokHareket
    {
        public int Id { get; set; }
        public string FisKodu { get; set; }
        public string FisBaglantiKodu { get; set; }
        public string Hareket { get; set; }
        public int StokId { get; set; }
        public Nullable<decimal> Miktar { get; set; }
        public int Kdv { get; set; }
        public Nullable<decimal> BirimFiyati { get; set; }
        public Nullable<decimal> AlisFiyati { get; set; }
        public Nullable<decimal> AlisFiyati2 { get; set; }
        public Nullable<decimal> AlisFiyati3 { get; set; }
        public Nullable<decimal> IndirimOrani { get; set; }
        public Nullable<decimal> ToplamTutar { get; set; }
        public Nullable<decimal> MevcutStok { get; set; }
        public Nullable<decimal> SayimMiktari { get; set; }

        public int DepoId { get; set; }

        public string SeriNo { get; set; }
        public Nullable<DateTime> Tarih { get; set; }
        public bool Siparis { get; set; }
        public bool Irsaliye { get; set; }
        public bool Teklif { get; set; }
        public string Aciklama { get; set; }
        public virtual Stok Stok { get; set; }
        public virtual Depo Depo { get; set; }
    }
}
