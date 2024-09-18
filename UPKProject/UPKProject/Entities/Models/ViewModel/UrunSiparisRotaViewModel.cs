using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModel
{
    public class UrunSiparisRotaViewModel
    {
        public int UrunSiparisId { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int? UrunTeslimMiktari { get; set; }
        public int UrunSiparisAdedi {  get; set; }
        public DateTime? UrunSiparisTarihi { get; set; }
        public DateTime? UrunTeslimTarihi { get; set; }
        public List<Rota> Rotalar {  get; set; }
    }
}
