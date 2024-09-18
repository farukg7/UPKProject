using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Atolye
    {
        public int AtolyeId { get; set; }
        public string? AtolyeAdi { get; set; }
        public ICollection<Rota> Rotalar { get; set; }
        public ICollection<AtolyeIsler> AtolyeIsler { get; set; }
    }
}
