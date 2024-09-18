using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UretimPlanlamaKontrol.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atolyeler",
                columns: table => new
                {
                    AtolyeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtolyeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atolyeler", x => x.AtolyeId);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.MusteriId);
                });

            migrationBuilder.CreateTable(
                name: "Projeler",
                columns: table => new
                {
                    ProjeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeler", x => x.ProjeId);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alan1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alan2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alan3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HediyePaketi = table.Column<bool>(type: "bit", nullable: false),
                    KargoDurumu = table.Column<bool>(type: "bit", nullable: false),
                    SiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.SiparisId);
                });

            migrationBuilder.CreateTable(
                name: "Tedarikciler",
                columns: table => new
                {
                    TedarikciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TedarikciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tedarikciler", x => x.TedarikciId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunMiktari = table.Column<int>(type: "int", nullable: true),
                    SatisFiyati = table.Column<int>(type: "int", nullable: true),
                    UrunResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmrı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_Urunler_Projeler_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Projeler",
                        principalColumn: "ProjeId");
                });

            migrationBuilder.CreateTable(
                name: "AtolyeIsler",
                columns: table => new
                {
                    AtolyeIslerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtolyeId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    UrunMiktari = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtolyeIsler", x => x.AtolyeIslerId);
                    table.ForeignKey(
                        name: "FK_AtolyeIsler_Atolyeler_AtolyeId",
                        column: x => x.AtolyeId,
                        principalTable: "Atolyeler",
                        principalColumn: "AtolyeId");
                    table.ForeignKey(
                        name: "FK_AtolyeIsler_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "Hammaddeler",
                columns: table => new
                {
                    HammaddeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HammaddeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HammaddeMiktari = table.Column<int>(type: "int", nullable: true),
                    AlisFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Birimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanimMiktari = table.Column<int>(type: "int", nullable: true),
                    OzetBilgi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HammaddeResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vitrin = table.Column<bool>(type: "bit", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hammaddeler", x => x.HammaddeId);
                    table.ForeignKey(
                        name: "FK_Hammaddeler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriId");
                    table.ForeignKey(
                        name: "FK_Hammaddeler_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "UrunSiparis",
                columns: table => new
                {
                    UrunSiparisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
                    ProjeId = table.Column<int>(type: "int", nullable: true),
                    UrunSiparisAdedi = table.Column<int>(type: "int", nullable: true),
                    UrunTeslimMiktari = table.Column<int>(type: "int", nullable: true),
                    UrunSiparisBirimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunSiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UrunTeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunSiparis", x => x.UrunSiparisId);
                    table.ForeignKey(
                        name: "FK_UrunSiparis_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriId");
                    table.ForeignKey(
                        name: "FK_UrunSiparis_Projeler_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Projeler",
                        principalColumn: "ProjeId");
                    table.ForeignKey(
                        name: "FK_UrunSiparis_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId");
                });

            migrationBuilder.CreateTable(
                name: "HammaddeSiparis",
                columns: table => new
                {
                    HammaddeSiparisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HammaddeId = table.Column<int>(type: "int", nullable: true),
                    TedarikciId = table.Column<int>(type: "int", nullable: true),
                    HammaddeSiparisAdedi = table.Column<int>(type: "int", nullable: true),
                    HammaddeGelenAdet = table.Column<int>(type: "int", nullable: true),
                    HammaddeSiparisBirimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HammaddeSiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HammaddeTeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HammaddeSiparis", x => x.HammaddeSiparisId);
                    table.ForeignKey(
                        name: "FK_HammaddeSiparis_Hammaddeler_HammaddeId",
                        column: x => x.HammaddeId,
                        principalTable: "Hammaddeler",
                        principalColumn: "HammaddeId");
                    table.ForeignKey(
                        name: "FK_HammaddeSiparis_Tedarikciler_TedarikciId",
                        column: x => x.TedarikciId,
                        principalTable: "Tedarikciler",
                        principalColumn: "TedarikciId");
                });

            migrationBuilder.CreateTable(
                name: "PlanLine",
                columns: table => new
                {
                    PlanLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HammaddeId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanLine", x => x.PlanLineId);
                    table.ForeignKey(
                        name: "FK_PlanLine_Hammaddeler_HammaddeId",
                        column: x => x.HammaddeId,
                        principalTable: "Hammaddeler",
                        principalColumn: "HammaddeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanLine_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "SiparisId");
                });

            migrationBuilder.CreateTable(
                name: "Planlama",
                columns: table => new
                {
                    PlanlamaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    UrunMiktari = table.Column<int>(type: "int", nullable: true),
                    UrunSiparisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planlama", x => x.PlanlamaId);
                    table.ForeignKey(
                        name: "FK_Planlama_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId");
                    table.ForeignKey(
                        name: "FK_Planlama_UrunSiparis_UrunSiparisId",
                        column: x => x.UrunSiparisId,
                        principalTable: "UrunSiparis",
                        principalColumn: "UrunSiparisId");
                });

            migrationBuilder.CreateTable(
                name: "Rotalar",
                columns: table => new
                {
                    RotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemSure = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    AtolyeId = table.Column<int>(type: "int", nullable: false),
                    IslemSırası = table.Column<int>(type: "int", nullable: false),
                    PlanlamaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotalar", x => x.RotaId);
                    table.ForeignKey(
                        name: "FK_Rotalar_Atolyeler_AtolyeId",
                        column: x => x.AtolyeId,
                        principalTable: "Atolyeler",
                        principalColumn: "AtolyeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rotalar_Planlama_PlanlamaId",
                        column: x => x.PlanlamaId,
                        principalTable: "Planlama",
                        principalColumn: "PlanlamaId");
                    table.ForeignKey(
                        name: "FK_Rotalar_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1287bd3a-5184-4948-a2af-b003b616bbaa", "bcdee8ea-9ff6-4e96-b429-8e1587d7576b", "SatinAlma", "SATINALMA" },
                    { "33738160-84e6-46be-88aa-73338c4f7363", "e4105fa4-6610-47b4-8cbd-52633acecbc7", "Depo", "DEPO" },
                    { "35778a4a-0e99-4ba6-ab7f-0b713ce8645a", "4280c011-9955-48c0-850c-c847644ef99b", "BoyaAtolye", "BOYAATOLYE" },
                    { "5ef836b4-5fa7-47a9-b1be-6c29349b1567", "115d95bd-0c5b-4e5f-8498-699eb1ea7d5f", "MontajAtolye", "MONTAJATOLYE" },
                    { "65d09a38-bf60-4024-b34c-308fd436b678", "eb780ca3-ba0a-4c26-a72c-809f6b3729bf", "MekanikAtolye", "MEKANIKATOLYE" },
                    { "88ff616e-194e-45ba-b4bc-74161d8eba06", "1727f321-a29b-4fba-b279-f8d0e49affa6", "Kalite", "KALITE" },
                    { "8cd8d518-283c-4d9a-b909-54603575068f", "c1bafa2b-36aa-40e3-9b07-59cb50938d8a", "Proje", "PROJE" },
                    { "91ba00fd-bf1a-4903-9014-4c7bf24a191d", "6b00fbf3-2d07-4d68-a6e7-0cae3003675d", "User", "USER" },
                    { "9ca6f1c9-2f1b-415e-a689-4891f5afd5e9", "b8700f7e-0e3f-4d76-b372-d59861bbe42a", "KablajAtolye", "KABLAJATOLYE" },
                    { "b6f787fa-5276-4013-8dd4-0d6803417ea9", "3a76ea67-d0bf-4e1a-951b-d7d40b1af241", "Planlama", "PLANLAMA" },
                    { "e6ebc1ce-c7d4-48ac-bd1a-fe5d36a2bd76", "cd7f5036-2192-4253-a5b8-777284a2fb86", "Yonetici", "YONETICI" }
                });

            migrationBuilder.InsertData(
                table: "Atolyeler",
                columns: new[] { "AtolyeId", "AtolyeAdi" },
                values: new object[,]
                {
                    { 1, "MekanikAtolye" },
                    { 2, "MontajAtolye" },
                    { 3, "KablajAtolye" },
                    { 4, "BoyaAtolye" }
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriId", "KategoriAdi" },
                values: new object[,]
                {
                    { 1, "Maske" },
                    { 2, "Sarf" }
                });

            migrationBuilder.InsertData(
                table: "Musteriler",
                columns: new[] { "MusteriId", "MusteriAdi" },
                values: new object[,]
                {
                    { 1, "FNSS" },
                    { 2, "BMC" }
                });

            migrationBuilder.InsertData(
                table: "Projeler",
                columns: new[] { "ProjeId", "ProjeAdi", "UrunId" },
                values: new object[,]
                {
                    { 1, "PARS ALPHA 8x8", null },
                    { 2, "ALTUĞ 8X8 ZMA", null }
                });

            migrationBuilder.InsertData(
                table: "Tedarikciler",
                columns: new[] { "TedarikciId", "TedarikciAdi" },
                values: new object[,]
                {
                    { 1, "Ismont" },
                    { 2, "Kaya Yapı Market" }
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "UrunId", "IsEmrı", "ProjeId", "SatisFiyati", "UrunAdi", "UrunMiktari", "UrunResimUrl" },
                values: new object[] { 1, null, 1, 4300, "DFG KBRN Gaz Maskesi", 0, "/images/5.jpg" });

            migrationBuilder.InsertData(
                table: "Hammaddeler",
                columns: new[] { "HammaddeId", "AlisFiyati", "Birimi", "HammaddeAdi", "HammaddeMiktari", "HammaddeResimUrl", "KategoriId", "KullanimMiktari", "OzetBilgi", "UrunId", "Vitrin" },
                values: new object[,]
                {
                    { 1, 560m, "Adet", "DFG KBRN Filtresiz Maske", 0, "/images/1.jpg", 1, 1, null, 1, false },
                    { 2, 420m, "Adet", "DFG KBRN Gaz Maske Filtresi", 0, "/images/2.jpg", 1, 1, null, 1, false },
                    { 3, 15m, "Adet", "M3 x 5 Yıldız Silindir Başlı (Ysb) Vida", 0, "/images/3.jpg", 2, 2, null, 1, false },
                    { 4, 3m, "Adet", "M3 Somun", 0, "/images/4.jpg", 2, 2, null, 1, false }
                });

            migrationBuilder.InsertData(
                table: "Rotalar",
                columns: new[] { "RotaId", "AtolyeId", "IslemSure", "IslemSırası", "PlanlamaId", "UrunId" },
                values: new object[,]
                {
                    { 1, 3, 40, 1, null, 1 },
                    { 2, 2, 30, 2, null, 1 },
                    { 3, 4, 20, 3, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AtolyeIsler_AtolyeId",
                table: "AtolyeIsler",
                column: "AtolyeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtolyeIsler_UrunId",
                table: "AtolyeIsler",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Hammaddeler_KategoriId",
                table: "Hammaddeler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Hammaddeler_UrunId",
                table: "Hammaddeler",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_HammaddeSiparis_HammaddeId",
                table: "HammaddeSiparis",
                column: "HammaddeId");

            migrationBuilder.CreateIndex(
                name: "IX_HammaddeSiparis_TedarikciId",
                table: "HammaddeSiparis",
                column: "TedarikciId");

            migrationBuilder.CreateIndex(
                name: "IX_Planlama_UrunId",
                table: "Planlama",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Planlama_UrunSiparisId",
                table: "Planlama",
                column: "UrunSiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanLine_HammaddeId",
                table: "PlanLine",
                column: "HammaddeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanLine_SiparisId",
                table: "PlanLine",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_Rotalar_AtolyeId",
                table: "Rotalar",
                column: "AtolyeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rotalar_PlanlamaId",
                table: "Rotalar",
                column: "PlanlamaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rotalar_UrunId",
                table: "Rotalar",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_ProjeId",
                table: "Urunler",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunSiparis_MusteriId",
                table: "UrunSiparis",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunSiparis_ProjeId",
                table: "UrunSiparis",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunSiparis_UrunId",
                table: "UrunSiparis",
                column: "UrunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AtolyeIsler");

            migrationBuilder.DropTable(
                name: "HammaddeSiparis");

            migrationBuilder.DropTable(
                name: "PlanLine");

            migrationBuilder.DropTable(
                name: "Rotalar");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tedarikciler");

            migrationBuilder.DropTable(
                name: "Hammaddeler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Atolyeler");

            migrationBuilder.DropTable(
                name: "Planlama");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "UrunSiparis");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Projeler");
        }
    }
}
