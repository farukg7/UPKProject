using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProjeService
    {
        IEnumerable<Proje> GetAllProjeler(bool trackChanges);
        Proje? GetOneProje(int id, bool trackChanges);
    }
}
