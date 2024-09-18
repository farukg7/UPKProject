using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Tedarikci
    {
        public int TedarikciId { get; set;}
        public string TedarikciAdi {  get; set;}
        public ICollection<HammaddeSiparis> HammaddeSiparisleri { get; set;}
    }
}
