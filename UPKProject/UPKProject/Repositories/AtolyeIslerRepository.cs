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
    public class AtolyeIslerRepository : RepositoryBase<AtolyeIsler>, IAtolyeIslerRepository
    {
        public AtolyeIslerRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneAtolyeIs(AtolyeIsler atolyeIs) => Create(atolyeIs);

        public IQueryable<AtolyeIsler> GetAllAtolyeIsler()
        {
            return _context.AtolyeIsler.Include(u => u.Urun);
        }

        public AtolyeIsler? GetOneAtolyeIslerByUrunIdAndAtolyeId(int uid, int aid, bool trackChanges)
        {
            return trackChanges
                ? _context.AtolyeIsler.FirstOrDefault(x => x.UrunId.Equals(uid) && x.AtolyeId.Equals(aid))
                : _context.AtolyeIsler.AsNoTracking().FirstOrDefault(x => x.UrunId.Equals(uid) && x.AtolyeId.Equals(aid));
        }

        public void UpdateOneAtolyeIs(AtolyeIsler atolyeIs)=>Update(atolyeIs);

       
    }
}
