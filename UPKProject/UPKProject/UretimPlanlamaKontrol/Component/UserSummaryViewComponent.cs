using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UretimPlanlamaKontrol.Component
{
    public class UserSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public UserSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.AuthService.GelAllUsers().Count().ToString();
        }
    }
}
