using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Hammadde
    {
        public int HammaddeId { get; set; }
        public string? HammaddeAdi { get; set; }
        public int? HammaddeMiktari { get; set; }      
        public decimal? AlisFiyati { get; set; }
        public string? Birimi { get; set; }
        public int? KullanimMiktari { get; set; }
        public string? OzetBilgi { get; set; }
        public String? HammaddeResimUrl { get; set; }
        public bool Vitrin { get; set; }
        public int? KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
        public int? UrunId { get; set; }
        public Urun? Urun { get; set; }
        public ICollection<HammaddeSiparis>? HammaddeSiparisler { get; set; }
    }
}
