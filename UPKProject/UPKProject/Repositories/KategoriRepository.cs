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
    public class KategoriRepository : RepositoryBase<Kategori>, IKategoriRepository
    {
        public KategoriRepository(RepositoryContext context) : base(context)
        {
        }

    
    }
}
