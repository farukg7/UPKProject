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
    public class TedarikciManager : ITedarikciService
    {
        private readonly IRepositoryManager _manager;

        public TedarikciManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Tedarikci> GetAllTedarikciler(bool trackChanges)
        {
           return _manager.Tedarikci.GetAllTedarikciler(trackChanges);
        }
    }
}
