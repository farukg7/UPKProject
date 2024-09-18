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
    public class UrunConfig : IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.HasData(
                new Urun() { UrunId=1, UrunAdi= "DFG KBRN Gaz Maskesi", UrunMiktari=0, SatisFiyati=4300, UrunResimUrl = "/images/5.jpg", ProjeId=1 }
                );
        }
    }
}
