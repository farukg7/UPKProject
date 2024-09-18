using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Plan
    {

        public List<PlanLine> Lines { get; set; }

        public Plan()
        {
            Lines = new List<PlanLine>();
        }

        public virtual void HammaddeEkle(Hammadde hammadde, int miktar)
        {
            PlanLine? line = Lines.Where(l => l.Hammadde.HammaddeId.Equals(hammadde.HammaddeId)).FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new PlanLine()
                {
                    Hammadde = hammadde,
                    Miktar = miktar
                });
            }
            else
            {
                line.Miktar += miktar;
            }
        }

        public virtual void HammaddeCikar(Hammadde hammadde) => Lines.RemoveAll(l => l.Hammadde.HammaddeId.Equals(hammadde.HammaddeId));

        public decimal? ToplamFiyatHesapla() => Lines.Sum(e => e.Hammadde.AlisFiyati * e.Miktar);

        public virtual void Temizle() => Lines.Clear();
    }
}
