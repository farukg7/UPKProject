using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IAtolyeRepository:IRepositoryBase<Atolye>
    {
        IQueryable<Atolye> GetAllAtolyeler(bool trackChanges);
        Atolye? GetOneAtolye(int id,bool trackChanges);
    }
}
