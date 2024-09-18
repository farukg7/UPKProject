using Entities.Models;

namespace UretimPlanlamaKontrol.Models
{
    public class HammaddeListViewModel
    {
        public IEnumerable<Hammadde> Hammaddeler { get; set; } = Enumerable.Empty<Hammadde>();
        public Pagination Pagination { get; set; } = new();
        public int TotalCount => Hammaddeler.Count();
    }
}
