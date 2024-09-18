using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Config;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace UretimPlanlamaKontrol.Repositories
{
    public class RepositoryContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Hammadde> Hammaddeler { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Proje> Projeler { get; set; }

        public DbSet<Urun> Urunler { get; set; }

        public DbSet<Siparis> Siparisler { get; set; }

        public DbSet<HammaddeSiparis> HammaddeSiparis { get; set; }

        public DbSet<UrunSiparis> UrunSiparis { get; set; }

        public DbSet<Rota> Rotalar { get; set; }

        public DbSet<Planlama > Planlama { get; set; }

        public DbSet<AtolyeIsler> AtolyeIsler { get; set; }

        public DbSet<Atolye> Atolyeler { get; set; }

        public DbSet<Musteri> Musteriler { get; set; }

        public DbSet<Tedarikci> Tedarikciler { get; set; }


        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new HammaddeConfig());
            //modelBuilder.ApplyConfiguration(new KategoriConfig());

            //assemblyde çalışan bütün configleri kapsaması için aşağıdaki tanımı yaptık

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
