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
    public class RotaConfig : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.HasData(
                new Rota() { RotaId = 1, IslemSure = 40, UrunId = 1, AtolyeId = 3, IslemSırası = 1 },
                new Rota() { RotaId = 2, IslemSure = 30, UrunId = 1, AtolyeId = 2, IslemSırası = 2 },
                new Rota() { RotaId = 3, IslemSure = 20, UrunId = 1, AtolyeId = 4, IslemSırası = 3 }
                );
        }
    }
}
