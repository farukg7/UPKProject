using UretimPlanlamaKontrol.Infrastructure.Extensions;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();//projeyi mvc yapabilmek i�in kulland�k

builder.Services.AddRazorPages();   //burada tan�mlad���m�z razor patchi endpointlerde de tan�mlamam�z gerekiyor 

builder.Services.ConfigureDbContext(builder.Configuration);     //geni�leterek kulland�k

builder.Services.ConfigureSession();    //geni�leterek kulland�k

builder.Services.ConfigureIdentity();

builder.Services.ConfigureRepositoryRegistration();     //geni�leterek kulland�k

builder.Services.ConfigureServiceRegistration();    //geni�leterek kulland�k

builder.Services.ConfigureRouting();    // endpointleri k���ltt�k, endpoint sonlar�na slash att�k

builder.Services.ConfigureApplicationCookie();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();   //Statik dosyalar�m�za eri�ebilmek i�in yazd�k(foto�raflar, vs)
app.UseSession();   //oturum y�netimi i�in alan� tan�mlad�k
app.UseHttpsRedirection();  //projeyi mvc yapabilmek i�in kulland�k
app.UseRouting();   //projeyi mvc yapabilmek i�in kulland�k

app.UseAuthentication();    //buradaki s�ralama �nemli �nce kullan�c�n�n oturum a�mas�ndan sonra di�er i�lemleri yapaca��z
app.UseAuthorization();


app.UseEndpoints(endpoints =>   //area tan�mlar� i�in birden fazla y�nlendirme mekanizmam�z olaca�� i�in a�a��daki ifadeyi yorum sat�r�na ald�k. burada y�neticiler, planlamac�lar, vs yer alacakt�r.
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
    pattern:"{controller=Account}/{action=Login}/{Id?}");//projeyi mvc yapabilmek i�in kulland�k

    endpoints.MapRazorPages();
});



//app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{Id?}");//projeyi mvc yapabilmek i�in kulland�k

app.ConfigureAndCheckMigration();
app.ConfigureDefaultYoneticiUser();
app.Run();
