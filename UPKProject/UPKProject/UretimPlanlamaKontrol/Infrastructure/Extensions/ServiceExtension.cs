using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories;
using UretimPlanlamaKontrol.Repositories;
using Services.Contracts;
using Services;
using Entities.Models;
using UretimPlanlamaKontrol.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace UretimPlanlamaKontrol.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("mssqlconnection"),
                b => b.MigrationsAssembly("UretimPlanlamaKontrol"));
            
                options.EnableSensitiveDataLogging(true);   //kullanıcı id sifreleri hassas bilgilerdir geliştirme aşamasında gözlenmek istenebilir uygulamaya geçildiğinde false a çekilmesi gerekir
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<RepositoryContext>();     //bu bilgileri nerde store edeceğimizi söyledik
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();   //oturum yönetimi için alanı tanımladık  burası bize bir ön bellek sağlıyor sunucu tarafında bilgileri saklıyor
            services.AddSession(options =>
            {
                options.Cookie.Name = "UPK.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });  //oturum yönetimi için alanı tanımladık

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Plan>(p => SessionPlan.GetPlan(p));
        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IHammaddeRepository, HammaddeRepository>();
            services.AddScoped<IKategoriRepository, KategoriRepository>();
            services.AddScoped<IUrunRepository, UrunRepository>();
            services.AddScoped<IProjeRepository, ProjeRepository>();
            services.AddScoped<ISiparisRepository, SiparisRepository>();
            services.AddScoped<IHammaddeSiparisRepository, HammaddeSiparisRepository>();
            services.AddScoped<IUrunSiparisRepository, UrunSiparisRepository>();
            services.AddScoped<IAtolyeRepository, AtolyeRepository>();
            services.AddScoped<IRotaRepository, RotaRepository>();
            services.AddScoped<IAtolyeIslerRepository, AtolyeIslerRepository>();
            services.AddScoped<IPlanlamaRepository, PlanlamaRepository>();
            services.AddScoped<ITedarikciRepository, TedarikciRepository>();
            services.AddScoped<IMusteriRepository, MusteriRepository>();
        }

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IHammaddeService, HammaddeManager>();
            services.AddScoped<IKategoriService, KategoriManager>();
            services.AddScoped<IUrunService, UrunManager>();
            services.AddScoped<IProjeService, ProjeManager>();
            services.AddScoped<ISiparisService, SiparisManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IHammaddeSiparisService, HammaddeSiparisManager>();
            services.AddScoped<IUrunSiparisService, UrunSiparisManager>();
            services.AddScoped<IAtolyeService, AtolyeManager>();
            services.AddScoped<IRotaService, RotaManager>();
            services.AddScoped<IAtolyeIslerService, AtolyeIslerManager>();
            services.AddScoped<IPlanlamaService, PlanlamaManager>();
            services.AddScoped<ITedarikciService, TedarikciManager>();
            services.AddScoped<IMusteriService, MusteriManager>();
        }

        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });
        }
    }
}
