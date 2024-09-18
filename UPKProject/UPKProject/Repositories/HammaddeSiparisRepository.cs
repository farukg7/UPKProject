using Entities.Models;
using Entities.Models.ViewModel;
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
    public class HammaddeSiparisRepository : RepositoryBase<HammaddeSiparis>, IHammaddeSiparisRepository
    {
        public HammaddeSiparisRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateHammaddeSiparis(HammaddeSiparis siparis) => Create(siparis);

        public List<HammaddeSiparis> GetAllHammaddeSiparislerByUrun(int urunId, bool trackChanges)
        {
            return trackChanges
                ? _context.HammaddeSiparis.Where(h => h.Hammadde.UrunId.Equals(urunId)).ToList()
                : _context.HammaddeSiparis.Where(h => h.Hammadde.UrunId.Equals(urunId)).AsNoTracking().ToList();
        }

        public List<HammaddeSiparis> GetAllHammaddeSiparislerByUrunAndSiparisTarihi(int id, bool trackChanges)
        {
            return trackChanges
                ? _context.HammaddeSiparis.Where(h => h.Hammadde.UrunId.Equals(id) && h.Hammadde.Urun.UrunSiparis.UrunTeslimTarihi < h.HammaddeSiparisTarihi).ToList()
                : _context.HammaddeSiparis.Where(h => h.Hammadde.UrunId.Equals(id) && h.Hammadde.Urun.UrunSiparis.UrunTeslimTarihi < h.HammaddeSiparisTarihi).AsNoTracking().ToList();
        }

        public IQueryable<HammaddeSiparis> GetAllHammadeSiparisler(bool trackChanges)
        {
            return trackChanges
                ? _context.HammaddeSiparis.Include(h => h.Hammadde).Include(h => h.Tedarikci)
                : _context.HammaddeSiparis.Include(h => h.Hammadde).Include(h => h.Tedarikci).AsNoTracking();
        }

        public HammaddeSiparis GetHammaddeSiparisById(int id,bool trackChanges)
        {
            return trackChanges
                ? _context.HammaddeSiparis.Include(h=>h.Hammadde).Where(hs => hs.HammaddeSiparisId.Equals(id)).FirstOrDefault()
                : _context.HammaddeSiparis.Include(h => h.Hammadde).Where(hs => hs.HammaddeSiparisId.Equals(id)).AsNoTracking().FirstOrDefault();
        }

        public void UpdateHammaddeSiparis(HammaddeSiparis hammaddeSiparis) => Update(hammaddeSiparis);
    }
}
