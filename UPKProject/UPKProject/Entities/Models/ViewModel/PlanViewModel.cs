using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModel
{
    public class PlanViewModel
    {
        public string? UrunAdi {  get; set; }
        public List<int>? UrunSiparisAdedi { get; set; } = new List<int>();
        public List<int>? UrunTeslimMiktari { get; set; } = new List<int>();
        public List<string>? HammaddeAdi { get; set; } = new List<string>();
        public List<int>? KullanimMiktari { get; set; } = new List<int>();
        public List<int>? HammaddeMiktari { get; set; } = new List<int>();
        public List<int>? HammaddeSiparisMiktari { get; set; } = new List<int>();
        public List<int>? ToplamGerekenMiktar { get; set; } = new List<int>();
        public List<int>? ZamanindaGelecekSiparisMiktari { get; set; } = new List<int>();
    }
}
