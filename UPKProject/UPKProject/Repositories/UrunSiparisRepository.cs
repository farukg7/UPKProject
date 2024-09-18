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
    public class UrunSiparisRepository : RepositoryBase<UrunSiparis>, IUrunSiparisRepository
    {
        public UrunSiparisRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneUrunSiparis(UrunSiparis urunSiparis) => Create(urunSiparis);


        public IQueryable<UrunSiparis> GetAllUrunSiparis(bool trackChanges)=>FindAll(trackChanges);

        public List<UrunSiparis> GetAllUrunSiparisByUrun(int id, bool trackChanges)
        {
            return trackChanges
                ? _context.UrunSiparis.Where(u => u.UrunId.Equals(id)).ToList()
                : _context.UrunSiparis.Where(u=>u.UrunId.Equals(id)).AsNoTracking().ToList();
        }

        public UrunSiparis GetOneUrunSiparis(int id, bool trackChanges)
        {
            return FindbyCondition(x => x.UrunId.Equals(id), trackChanges);
        }

        public void UpdateOneUrunSiparis(UrunSiparis urunSiparis) => Update(urunSiparis);
    }
}
