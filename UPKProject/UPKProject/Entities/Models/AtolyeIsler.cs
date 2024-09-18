using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AtolyeIsler
    {
        public int AtolyeIslerId { get; set; }
        public int? AtolyeId { get; set; }
        public Atolye? Atolye { get; set; }
        public int? UrunId { get; set; }
        public Urun? Urun { get; set; }
        public int? UrunMiktari { get; set; }
    }
}
