using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UretimPlanlamaKontrol.Repositories;

namespace Repositories
{
    public class AtolyeRepository : RepositoryBase<Atolye>, IAtolyeRepository
    {
        public AtolyeRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Atolye> GetAllAtolyeler(bool trackChanges)=>FindAll(trackChanges);

        public Atolye? GetOneAtolye(int id, bool trackChanges)
        {
            return FindbyCondition(x => x.AtolyeId.Equals(id), trackChanges);
        }
    }
}
