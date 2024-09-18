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
    public class TedarikciConfig : IEntityTypeConfiguration<Tedarikci>
    {
        public void Configure(EntityTypeBuilder<Tedarikci> builder)
        {
            builder.HasData(
                new Tedarikci() { TedarikciId=1, TedarikciAdi="Ismont"},
                new Tedarikci() { TedarikciId=2, TedarikciAdi="Kaya Yapı Market"}
                );
        }
    }
}
