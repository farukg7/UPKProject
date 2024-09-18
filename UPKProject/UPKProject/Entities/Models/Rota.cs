using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Rota
    {
        public int RotaId { get; set; }
        public int? IslemSure { get; set; }
        public int UrunId { get; set; }
        public Urun? Urun { get; set; }
        public int AtolyeId { get; set; }
        public Atolye? Atolye { get; set; }
        public int IslemSırası { get; set; }
        public int? PlanlamaId { get; set; }
        public Planlama? Planlama { get; set; }

    }
}
