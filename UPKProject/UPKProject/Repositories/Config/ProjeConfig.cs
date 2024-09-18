using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProjeConfig:IEntityTypeConfiguration<Proje>
    {
        public void Configure(EntityTypeBuilder<Proje> builder)
        {
            builder.HasData(              
                new Proje() { ProjeId = 1, ProjeAdi = "PARS ALPHA 8x8" },
                new Proje() { ProjeId = 2, ProjeAdi = "ALTUĞ 8X8 ZMA" }
                );
        }
    }
}
