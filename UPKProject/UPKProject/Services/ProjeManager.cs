using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProjeManager : IProjeService
    {
        private readonly IRepositoryManager _manager;

        public ProjeManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Proje> GetAllProjeler(bool trackChanges)
        {
            return _manager.Proje.GetAllProjeler(trackChanges);
        }

        public Proje? GetOneProje(int id, bool trackChanges)
        {
            return _manager.Proje.GetOneProje(id, trackChanges);
        }
    }
}
