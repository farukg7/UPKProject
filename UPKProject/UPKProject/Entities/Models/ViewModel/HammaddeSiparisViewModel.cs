using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModel
{
    public class HammaddeSiparisViewModel
    {
        public int HammaddeSiparisId { get; set; }
        public int HammaddeId { get; set; }
        public string? HammaddeAdi {  get; set; }
        public int? TedarikciId { get; set; }
        public string? TedarikciAdi {  get; set; }
        public int? HammaddeSiparisAdedi { get; set; }
        public int? HammaddeGelenAdet { get; set; } = 0;
        public string? HammaddeSiparisBirimi { get; set; }
        public DateTime? HammaddeSiparisTarihi { get; set; }= DateTime.Now;
        public DateTime? HammaddeTeslimTarihi { get; set; }
    }
}
