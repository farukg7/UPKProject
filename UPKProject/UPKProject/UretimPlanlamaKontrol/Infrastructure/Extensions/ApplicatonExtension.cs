using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UretimPlanlamaKontrol.Repositories;

namespace UretimPlanlamaKontrol.Infrastructure.Extensions
{
    //bu genişleme ifadeleriyle birlikte artık dotnet ef database update komutuna ihtiyacım olmayacak
    public static class ApplicatonExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public static async void ConfigureDefaultYoneticiUser(this IApplicationBuilder app)
        {
            const string yoneticiUser = "Admin";
            const string yoneticiPassword = "Admin+123456";

            UserManager<IdentityUser> userManager=app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
       
            RoleManager<IdentityRole> roleManager=app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();
        
            IdentityUser user= await userManager.FindByNameAsync(yoneticiUser);
            if (user == null)
            {
                user = new IdentityUser(yoneticiUser)
                {
                    Email = "fguvercin@hotmail.com",
                    PhoneNumber = "5554443322",
                    UserName = yoneticiUser
                };

                var result = await userManager.CreateAsync(user, yoneticiPassword);

                if(!result.Succeeded)
                    throw new Exception("Yonetici kullanıcı oluşturulamadı.");


                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                    .Roles
                    .Select(r => r.Name)
                    .ToList()
                    );//yönetici kullanıcısına bütün rolleri atamış olduk.

                if (!roleResult.Succeeded)
                    throw new Exception("Admin kullanıcısına rol atamaları esnasında bir sorun oluştu.");

            }
        }
    }
}
