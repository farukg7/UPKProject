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
    public class KategoriConfig : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(
                //new Kategori() { KategoriId = 1, KategoriAdi = "Şase" },
                //new Kategori() { KategoriId = 2, KategoriAdi = "Kabin" },
                new Kategori() { KategoriId = 1, KategoriAdi = "Maske" },
                new Kategori() { KategoriId = 2, KategoriAdi = "Sarf" }
                );
        }
    }
}
