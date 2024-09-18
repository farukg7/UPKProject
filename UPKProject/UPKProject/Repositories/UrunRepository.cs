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
    public class UrunRepository : RepositoryBase<Urun>, IUrunRepository
    {
        public UrunRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneUrun(Urun urun) => Create(urun);

        public List<Urun> GetAllUrunByNotNullUrunSiparis(bool trackChanges)
        {
            return trackChanges
                 ? _context.Urunler.Where(u => u.UrunSiparis != null).ToList()
                 : _context.Urunler.Where(u => u.UrunSiparis != null).AsNoTracking().ToList();
        }

        public IQueryable<Urun> GetAllUrunler(bool trackChanges)
        {
            return trackChanges
                ? _context.Urunler.Include(u => u.Rotalar).Include(u => u.Proje).Include(u=>u.Hammaddeler)
                : _context.Urunler.Include(u => u.Rotalar).Include(u => u.Proje).Include(u => u.Hammaddeler).AsNoTracking();
        }

        public Urun? GetMaxIdUrun(bool trackChanges)
        {
            return trackChanges
                ? _context.Urunler.OrderByDescending(u => u.UrunId).FirstOrDefault()
                : _context.Urunler.OrderByDescending(u => u.UrunId).AsNoTracking().FirstOrDefault();
        }

        public Urun? GetOneUrun(int id, bool trackChanges)
        {
            return FindbyCondition(urn => urn.UrunId.Equals(id), trackChanges);
        }

        public void UpdateOneUrun(Urun urun) => Update(urun);
    }
}
