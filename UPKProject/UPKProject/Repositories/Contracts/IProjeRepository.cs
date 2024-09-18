using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProjeRepository:IRepositoryBase<Proje>
    {
        IQueryable<Proje> GetAllProjeler(bool trackChanges);
        Proje? GetOneProje(int id, bool trackChanges);
    }
}
