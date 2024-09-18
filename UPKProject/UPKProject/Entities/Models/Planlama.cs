using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Planlama
    {
        public int PlanlamaId { get; set; }
        public int? UrunId { get; set; }
        public Urun? Urun { get; set; }
        public int? UrunMiktari { get; set; }
        public int? UrunSiparisId { get; set; }
        public UrunSiparis? UrunSiparis { get; set; }
        public ICollection<Rota> Rotalar {  get; set; }=new List<Rota>();
    }
}
