using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModel
{
    public class UrunSiparisViewModel
    {
        public int UrunSiparisId { get; set; }
        public int? UrunId { get; set; }
        public string? UrunAdi { get; set; }
        public int? MusteriId { get; set; }
        public string? MusteriAdi { get; set; }
        public int? ProjeId { get; set; }
        public string? ProjeAdi { get; set; }
        public int? UrunSiparisAdedi {  get; set; }
        public int? UrunTeslimMiktari { get; set; } = 0;
        public string? UrunSiparisBirimi { get; set; }
        public DateTime? UrunSiparisTarihi { get; set; } = DateTime.Now;
        public DateTime? UrunTeslimTarihi { get; set; }
    }
}
