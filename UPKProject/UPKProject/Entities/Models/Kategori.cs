﻿namespace Entities.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string? KategoriAdi { get; set; }
        public ICollection<Hammadde> Hammaddeler { get; set; }
    }
}
