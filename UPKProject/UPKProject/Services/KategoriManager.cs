using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class KategoriManager : IKategoriService
    {
        private readonly IRepositoryManager _manager;

        public KategoriManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Kategori> GetAllKategoriler(bool trackChanges)
        {
            return _manager.Kategori.FindAll(trackChanges);
        }
    }
}
