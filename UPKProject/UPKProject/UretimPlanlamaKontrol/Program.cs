using UretimPlanlamaKontrol.Infrastructure.Extensions;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//projeyi mvc yapabilmek için kullandýk

builder.Services.AddRazorPages();   //burada tanýmladýðýmýz razor patchi endpointlerde de tanýmlamamýz gerekiyor 

builder.Services.ConfigureDbContext(builder.Configuration);     //geniþleterek kullandýk

builder.Services.ConfigureSession();    //geniþleterek kullandýk

builder.Services.ConfigureIdentity();

builder.Services.ConfigureRepositoryRegistration();     //geniþleterek kullandýk

builder.Services.ConfigureServiceRegistration();    //geniþleterek kullandýk

builder.Services.ConfigureRouting();    // endpointleri küçülttük, endpoint sonlarýna slash attýk

builder.Services.ConfigureApplicationCookie();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();   //Statik dosyalarýmýza eriþebilmek için yazdýk(fotoðraflar, vs)
app.UseSession();   //oturum yönetimi için alaný tanýmladýk
app.UseHttpsRedirection();  //projeyi mvc yapabilmek için kullandýk
app.UseRouting();   //projeyi mvc yapabilmek için kullandýk

app.UseAuthentication();    //buradaki sýralama önemli önce kullanýcýnýn oturum açmasýndan sonra diðer iþlemleri yapacaðýz
app.UseAuthorization();


app.UseEndpoints(endpoints =>   //area tanýmlarý için birden fazla yönlendirme mekanizmamýz olacaðý için aþaðýdaki ifadeyi yorum satýrýna aldýk. burada yöneticiler, planlamacýlar, vs yer alacaktýr.
{
    endpoints.MapAreaControllerRoute(
    name:"Yonetici",
    areaName:"Yonetici",
    pattern:"Yonetici/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapAreaControllerRoute(
    name: "Depo",
    areaName: "Depo",
    pattern: "Depo/{controller=Hammadde}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "Planlama",
    pattern: "planlama/{action=Index}/{id?}",
    defaults: new { controller = "Planlama", area = "Planlama" }
    );
    endpoints.MapAreaControllerRoute(
    name: "Atolye",
    areaName: "Atolye",
    pattern: "Atolye/{controller=Atolye}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "Proje",
    pattern: "proje/{action=Index}/{id?}",
    defaults: new { controller="Proje", area="Proje" }
    );

    endpoints.MapControllerRoute(
    name:"default", 
    pattern:"{controller=Account}/{action=Login}/{Id?}");//projeyi mvc yapabilmek için kullandýk

    endpoints.MapRazorPages();
});



//app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{Id?}");//projeyi mvc yapabilmek için kullandýk

app.ConfigureAndCheckMigration();
app.ConfigureDefaultYoneticiUser();
app.Run();
