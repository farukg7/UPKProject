using Entities.Models;
using Entities.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPlanlamaService
    {
        List<PlanViewModel> GetAllSiparis();
        IEnumerable<Planlama> GetAllPlanlamalar(bool trackChanges);
        Planlama? GetOnePlanlamaByUrunSiparisId(int id, bool trackChanges);
        void CreatePlan(Planlama planlama);
        void UpdatePlanlama(Planlama planlama);
    }
}
