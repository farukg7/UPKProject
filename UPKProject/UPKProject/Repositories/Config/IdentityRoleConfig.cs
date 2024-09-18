using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole() { Name = "User", NormalizedName = "USER" },
                new IdentityRole() { Name = "Yonetici", NormalizedName = "YONETICI" },
                new IdentityRole() { Name = "Proje", NormalizedName = "PROJE" },
                new IdentityRole() { Name = "Planlama", NormalizedName = "PLANLAMA" },
                new IdentityRole() { Name = "Kalite", NormalizedName = "KALITE" },
                new IdentityRole() { Name = "SatinAlma", NormalizedName = "SATINALMA" },
                new IdentityRole() { Name = "Depo", NormalizedName = "DEPO" },
                new IdentityRole() { Name = "MekanikAtolye", NormalizedName = "MEKANIKATOLYE" },
                new IdentityRole() { Name = "MontajAtolye", NormalizedName = "MONTAJATOLYE" },
                new IdentityRole() { Name = "KablajAtolye", NormalizedName = "KABLAJATOLYE" },
                new IdentityRole() { Name = "BoyaAtolye", NormalizedName = "BOYAATOLYE" }
                );
        }
    }
}
