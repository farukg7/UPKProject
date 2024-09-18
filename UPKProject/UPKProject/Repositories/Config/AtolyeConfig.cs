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
    public class AtolyeConfig : IEntityTypeConfiguration<Atolye>
    {
        public void Configure(EntityTypeBuilder<Atolye> builder)
        {
            builder.HasData(
                new Atolye() { AtolyeId = 1, AtolyeAdi = "MekanikAtolye" },
                new Atolye() { AtolyeId = 2, AtolyeAdi = "MontajAtolye" },
                new Atolye() { AtolyeId = 3, AtolyeAdi = "KablajAtolye" },
                new Atolye() { AtolyeId = 4, AtolyeAdi = "BoyaAtolye" }
                );
        }
    }
}
