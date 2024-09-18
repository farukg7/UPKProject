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
    public class TedarikciRepository : RepositoryBase<Tedarikci>, ITedarikciRepository
    {
        public TedarikciRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Tedarikci> GetAllTedarikciler(bool trackChanges) => FindAll(trackChanges);
    }
}
