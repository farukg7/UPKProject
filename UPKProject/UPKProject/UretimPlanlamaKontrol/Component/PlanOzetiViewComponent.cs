using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace UretimPlanlamaKontrol.Component
{
    public class PlanOzetiViewComponent:ViewComponent
    {
        private readonly Plan _plan;

        public PlanOzetiViewComponent(Plan planService)
        {
            _plan = planService;
        }

        public string Invoke()
        {
            return _plan.Lines.Count().ToString();
        }
    }
}
