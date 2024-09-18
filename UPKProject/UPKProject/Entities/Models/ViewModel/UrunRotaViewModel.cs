using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ViewModel
{
    public class UrunRotaViewModel
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int AtolyeId { get; set; }
        public int IslemSure { get; set; }
        public int IslemSırası { get; set; }
        public ICollection<Rota> Rotalar {  get; set; }=new List<Rota>();
        public ICollection<Atolye> Atolyeler { get; set; } = new List<Atolye>();
    }
}
