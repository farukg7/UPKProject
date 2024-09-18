using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MusteriManager:IMusteriService
    {
        private readonly IRepositoryManager _manager;

        public MusteriManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Musteri> GetAllMusteriler(bool trackChanges)
        {
            return _manager.Musteri.GetAllMusteriler(trackChanges);
        }
    }
}
