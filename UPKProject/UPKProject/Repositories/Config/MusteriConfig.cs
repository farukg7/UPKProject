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
    public class MusteriConfig:IEntityTypeConfiguration<Musteri>
    {
        public void Configure(EntityTypeBuilder<Musteri> builder)
        {
            builder.HasData(
                new Musteri() { MusteriId=1, MusteriAdi="FNSS"},
                new Musteri() { MusteriId=2, MusteriAdi="BMC"}
                );
        }
    }
}
