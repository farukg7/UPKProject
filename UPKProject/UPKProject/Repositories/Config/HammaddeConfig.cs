using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class HammaddeConfig : IEntityTypeConfiguration<Hammadde>
    {
        public void Configure(EntityTypeBuilder<Hammadde> builder)
        {
            builder.HasData(
                //new Hammadde() { HammaddeId = 1, KategoriId = 1, ResimUrl = "/images/1.jpg" , HammaddeAdi = "KVF25 Aluminyum Şase", AlisFiyati = 125, Vitrin=false},
                //new Hammadde() { HammaddeId = 2, KategoriId = 2, ResimUrl = "/images/2.jpg" , HammaddeAdi = "30-220 kVA SA Svy 1 Kabin", AlisFiyati = 340, Vitrin = false },
                //new Hammadde() { HammaddeId = 3, KategoriId = 1, ResimUrl = "/images/3.jpg" , HammaddeAdi = "DFG-52 Karbon Şase", AlisFiyati = 340, Vitrin = true },
                //new Hammadde() { HammaddeId = 4, KategoriId = 2, ResimUrl = "/images/4.jpg" , HammaddeAdi = "24-220 kVA SA Svy 2 Kabin", AlisFiyati = 340, Vitrin = true },
                new Hammadde() { HammaddeId = 1, HammaddeAdi = "DFG KBRN Filtresiz Maske", HammaddeMiktari =0, AlisFiyati=560, Birimi="Adet", KullanimMiktari = 1, HammaddeResimUrl = "/images/1.jpg", KategoriId = 1, UrunId=1 },
                new Hammadde() { HammaddeId = 2, HammaddeAdi = "DFG KBRN Gaz Maske Filtresi", HammaddeMiktari = 0, AlisFiyati = 420, Birimi = "Adet", KullanimMiktari = 1, HammaddeResimUrl = "/images/2.jpg", KategoriId = 1, UrunId = 1 },
                new Hammadde() { HammaddeId = 3, HammaddeAdi = "M3 x 5 Yıldız Silindir Başlı (Ysb) Vida", HammaddeMiktari = 0, AlisFiyati = 15, Birimi = "Adet", KullanimMiktari = 2, HammaddeResimUrl = "/images/3.jpg", KategoriId = 2, UrunId = 1 },
                new Hammadde() { HammaddeId = 4, HammaddeAdi = "M3 Somun", HammaddeMiktari = 0, AlisFiyati = 3, Birimi = "Adet", KullanimMiktari = 2, HammaddeResimUrl = "/images/4.jpg", KategoriId = 2, UrunId = 1 }

                );
        }
    }
} 
