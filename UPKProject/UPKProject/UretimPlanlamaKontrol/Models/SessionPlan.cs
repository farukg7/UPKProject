using Entities.Models;
using System.Text.Json.Serialization;
using UretimPlanlamaKontrol.Infrastructure.Extensions;

namespace UretimPlanlamaKontrol.Models
{
    public class SessionPlan:Plan
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Plan GetPlan(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext.Session;

            SessionPlan plan = session?.GetJson<SessionPlan>("plan") ?? new SessionPlan();
            plan.Session = session;
            return plan;
        }

        public override void HammaddeEkle(Hammadde hammadde, int miktar)
        {
            base.HammaddeEkle(hammadde, miktar);
            Session?.SetJson<SessionPlan>("plan",this);
        }

        public override void Temizle()
        {
            base.Temizle();
            Session?.Remove("plan");
        }

        public override void HammaddeCikar(Hammadde hammadde)
        {
            base.HammaddeCikar(hammadde);
            Session?.SetJson<SessionPlan>("plan", this);
        }
    }
}
