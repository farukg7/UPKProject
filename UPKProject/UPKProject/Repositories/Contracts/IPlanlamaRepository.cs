using Entities.Models;
using Entities.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPlanlamaRepository:IRepositoryBase<Planlama>
    {
        List<PlanViewModel> GetAllSiparis();
        IQueryable<Planlama> GetAllPlanlama(bool trackChanges);
        Planlama? GetOnePlanlamaByUrunSiparisId(int id,bool trackChanges);
        void CreatePlan(Planlama planlama);
        void UpdatePlan(Planlama planlama);
    }
}
