using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public ICollection<PlanLine> Lines { get; set; }=new List<PlanLine>();
        [Required(ErrorMessage ="Sipariş adı zorunludur.")]
        public String? Adi { get; set; }
        public String? Alan1 { get; set; }
        public String? Alan2 { get; set; }
        public String? Alan3 { get; set; }
        public String Sehir { get; set; }
        public bool HediyePaketi {  get; set; }
        public bool KargoDurumu {  get; set; }
        public DateTime SiparisTarihi { get; set; } = DateTime.Now; 
    }
}
