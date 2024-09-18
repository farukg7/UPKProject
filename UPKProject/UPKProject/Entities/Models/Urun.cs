namespace Entities.Models
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string? UrunAdi { get; set; }
        public int? UrunMiktari { get; set; }
        public int? SatisFiyati { get; set; }
        public String? UrunResimUrl { get; set; }
        public string? IsEmrı { get; set; }
        public Planlama? Planlama { get; set; }
        public int? ProjeId { get; set; }
        public Proje? Proje { get; set; }
        public ICollection<Hammadde> Hammaddeler { get; set; }
        public UrunSiparis? UrunSiparis { get; set; }
        public ICollection<Rota> Rotalar { get; set; }
        public ICollection<AtolyeIsler> AtolyeIsler { get;set; }
    }   
}
