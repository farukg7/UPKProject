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
    public class ProjeRepository : RepositoryBase<Proje>, IProjeRepository
    {
        public ProjeRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Proje> GetAllProjeler(bool trackChanges) => FindAll(trackChanges);

        public Proje? GetOneProje(int id, bool trackChanges)
        {
            return trackChanges
                ? _context.Projeler.Where(p => p.UrunId.Equals(id)).FirstOrDefault()
                : _context.Projeler.Where(p => p.UrunId.Equals(id)).AsNoTracking().FirstOrDefault();
        }
    }
}
