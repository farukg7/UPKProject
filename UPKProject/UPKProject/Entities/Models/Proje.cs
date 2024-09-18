namespace Entities.Models

{
    public class Proje
    {
        public int ProjeId { get; set; }
        public string? ProjeAdi { get; set; }
        public int? UrunId { get; set; }
        public ICollection<Urun> Urunler { get; set; }
    }
}
