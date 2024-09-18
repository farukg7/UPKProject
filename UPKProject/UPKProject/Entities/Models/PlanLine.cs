using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PlanLine
    {
        public int PlanLineId { get; set; }
        public Hammadde Hammadde { get; set; } = new();
        public int Miktar {  get; set; }
    }
}
