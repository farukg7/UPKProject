using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModel
{
    public class MalKabulViewModel
    {
        public int HammaddeSiparisId { get; set; }
        public string? HammaddeAdi { get; set; }
        public int? HammaddeSiparisAdedi { get; set; }
        public int? HammaddeGelenAdet { get; set; } = 0;
    }
}
