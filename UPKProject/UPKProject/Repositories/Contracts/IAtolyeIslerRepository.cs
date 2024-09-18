using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IAtolyeIslerRepository:IRepositoryBase<AtolyeIsler>
    {
        void CreateOneAtolyeIs(AtolyeIsler atolyeIs);
        void UpdateOneAtolyeIs(AtolyeIsler atolyeIs);
        IQueryable<AtolyeIsler> GetAllAtolyeIsler();
        AtolyeIsler? GetOneAtolyeIslerByUrunIdAndAtolyeId(int uid, int aid, bool trackChanges);
    }
}
