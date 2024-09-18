using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModel
{
    public class HammaddePlanViewModel
    {
        public string HammaddeAdi { get; set; }
        public int HammaddeMiktari { get; set; }     
        public int AlisFiyati { get; set; }
        public string Birimi { get; set; }
        public int KullanimMiktari {  get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
    }
}
