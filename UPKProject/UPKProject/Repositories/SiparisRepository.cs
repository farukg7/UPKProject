using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UretimPlanlamaKontrol.Repositories;

namespace Repositories
{
    public class SiparisRepository : RepositoryBase<Siparis>, ISiparisRepository
    {
        public SiparisRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Siparis> Siparisler => _context.Siparisler.Include(s => s.Lines).ThenInclude(cl => cl.Hammadde).OrderBy(o => o.KargoDurumu).ThenByDescending(o => o.SiparisId);

        public int TamamlananSiparisler => _context.Siparisler.Count(o => o.KargoDurumu.Equals(false));

        public Siparis GetOneSiparis(int id)
        {
            return FindbyCondition(o => o.SiparisId.Equals(id), false);
        }

        public void SiparisiKaydet(Siparis siparis)
        {
            _context.AttachRange(siparis.Lines.Select(l => l.Hammadde));
            if (siparis.SiparisId == 0)
                _context.Siparisler.Add(siparis);
            _context.SaveChanges();
        }

        public void Tamamla(int id)
        {
            var order = FindbyCondition(o => o.SiparisId.Equals(id),true);
            if (order is null)
                throw new Exception("Sipariş bulunamadı");
            order.KargoDurumu = true;

        }
    }
}
