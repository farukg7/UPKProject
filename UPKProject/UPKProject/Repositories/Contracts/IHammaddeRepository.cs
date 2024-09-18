using Entities.Models;
using Entities.Models.ViewModel;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IHammaddeRepository:IRepositoryBase<Hammadde>
    {
        IQueryable<Hammadde> GetAllHammadeler(bool trackChanges);
        IQueryable<Hammadde> GetAllHammaddelerWithDetails(HammaddeRequestParameters p);
        IQueryable<Hammadde> GetVitrinHamaddeler(bool trackChanges);
        Hammadde? GetOneHammadde(int id, bool trackChanges);
        void CreateOneHammadde(Hammadde hammadde);
        void DeleteOneHammadde(Hammadde hammadde);
        void UpdateOneHammade(Hammadde hammadde);
        List<Hammadde> GetAllHammaddelerByUrun(int id, bool trackChanges);
        void UpdateHammaddeler(IEnumerable<Hammadde> hammaddeler);
    }
}
