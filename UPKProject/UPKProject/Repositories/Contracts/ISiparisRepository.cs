using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ISiparisRepository
    {
        IQueryable<Siparis> Siparisler { get; }
        Siparis? GetOneSiparis(int id);
        void Tamamla(int id);
        void SiparisiKaydet(Siparis siparis);
        int TamamlananSiparisler {  get; }
    }
}
