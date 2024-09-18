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
    public class RotaRepository : RepositoryBase<Rota>, IRotaRepository
    {
        public RotaRepository(RepositoryContext context) : base(context)
        {
        }

        public Rota? FindUrunAndRota(int urunId, int atolyeId, bool trackChanges)
        {
            return trackChanges
                ? _context.Rotalar.Where(r => r.UrunId.Equals(urunId) && r.AtolyeId.Equals(atolyeId)).FirstOrDefault()
                : _context.Rotalar.Where(r => r.UrunId.Equals(urunId) && r.AtolyeId.Equals(atolyeId)).AsNoTracking().FirstOrDefault();
        }

        public IQueryable<Rota> GetRotasByUrun(int id, bool trackChanges)
        {
            return trackChanges
                ? _context.Rotalar.Where(r => r.UrunId.Equals(id))
                : _context.Rotalar.Where(r => r.UrunId.Equals(id)).AsNoTracking();
        }

        public Rota? GetOneUrunByRota(int id, bool trackChanges)
        {
            return trackChanges
                ? _context.Rotalar.Where(x => x.UrunId.Equals(id) && x.IslemSırası==1).FirstOrDefault()
                : _context.Rotalar.Where(x => x.UrunId.Equals(id) && x.IslemSırası==1).AsNoTracking().FirstOrDefault();
        }

        public Rota? NextRota(int id, bool trackChanges)
        {
            return trackChanges
                ? _context.Rotalar.Where(nr => nr.IslemSırası.Equals(id)).FirstOrDefault()
                : _context.Rotalar.Where(nr => nr.IslemSırası.Equals(id)).AsNoTracking().FirstOrDefault();
        }

        public void UpdateRotas(IEnumerable<Rota> rotalar)
        {
            foreach (var r in rotalar)
            {
                _context.Rotalar.Update(r);
            }
            _context.SaveChanges();
        }

        public void CreateRota(Rota rota)=>Create(rota);
    }
}
