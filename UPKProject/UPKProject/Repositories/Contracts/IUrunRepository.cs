using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUrunRepository:IRepositoryBase<Urun>
    {
        List<Urun> GetAllUrunByNotNullUrunSiparis(bool trackChanges);
        IQueryable<Urun> GetAllUrunler(bool trackChanges);
        Urun GetOneUrun(int id, bool trackChanges);
        Urun? GetMaxIdUrun(bool trackChanges);
        void CreateOneUrun(Urun urun);
        void UpdateOneUrun(Urun urun);
    }
}
