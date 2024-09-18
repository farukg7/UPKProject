using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SiparisManager : ISiparisService
    {
        private readonly IRepositoryManager _manager;

        public SiparisManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Siparis> Siparisler => _manager.Siparis.Siparisler;

        public int TamamlananSiparisler => _manager.Siparis.TamamlananSiparisler;

        public Siparis? GetOneSiparis(int id)
        {
            return _manager.Siparis.GetOneSiparis(id);
        }

        public void SiparisiKaydet(Siparis siparis)
        {
            _manager.Siparis.SiparisiKaydet(siparis);
        }

        public void Tamamla(int id)
        {
            _manager.Siparis.Tamamla(id);
            _manager.Save();
        }
    }
}
