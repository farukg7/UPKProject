using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModel
{
    public class UrunHammaddeViewModel
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int KullanimMiktari { get; set; }
        public Urun Urun { get; set; }
        public ICollection<Hammadde> Hammaddeler { get; set; } = new List<Hammadde>();
    }
}
