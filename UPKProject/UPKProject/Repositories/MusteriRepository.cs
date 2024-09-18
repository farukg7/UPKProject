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
    public class MusteriRepository : RepositoryBase<Musteri>, IMusteriRepository
    {
        public MusteriRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Musteri> GetAllMusteriler(bool trackChanges)=>FindAll(trackChanges);
    }
}
