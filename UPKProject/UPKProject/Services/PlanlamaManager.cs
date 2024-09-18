using Entities.Models;
using Entities.Models.ViewModel;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PlanlamaManager : IPlanlamaService
    {
        private readonly IRepositoryManager _manager;

        public PlanlamaManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreatePlan(Planlama planlama)
        {
            _manager.Planlama.CreatePlan(planlama);
            _manager.Save();
        }

        public IEnumerable<Planlama> GetAllPlanlamalar(bool trackChanges)
        {
            return _manager.Planlama.GetAllPlanlama(trackChanges).ToList();
        }

        public List<PlanViewModel> GetAllSiparis()
        {
            return _manager.Planlama.GetAllSiparis();
        }

        public Planlama? GetOnePlanlamaByUrunSiparisId(int id, bool trackChanges)
        {
            return _manager.Planlama.GetOnePlanlamaByUrunSiparisId(id, trackChanges);
        }

        public void UpdatePlanlama(Planlama planlama)
        {
            _manager.Planlama.UpdatePlan(planlama);
            _manager.Save();
        }
    }
}
