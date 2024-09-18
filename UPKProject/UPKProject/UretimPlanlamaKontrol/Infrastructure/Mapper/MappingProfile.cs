using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace UretimPlanlamaKontrol.Infrastructure.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<HammaddeDtoForInsertion, Hammadde>();
            CreateMap<HammaddeDtoForUpdate, Hammadde>().ReverseMap();
            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
            CreateMap<HammaddeSiparis, MalKabulViewModel>()
            .ForMember(dest=>dest.HammaddeAdi, opt=>opt.MapFrom(src=>src.Hammadde.HammaddeAdi))    
            .ReverseMap();
            CreateMap<UrunSiparis, UrunSiparisRotaViewModel>();
            CreateMap<UrunSiparis, UrunSiparisRotaViewModel>()
                .ForMember(dest => dest.UrunAdi, opt => opt.MapFrom(src => src.Urun.UrunAdi))
                .ForMember(dest => dest.Rotalar, opt => opt.MapFrom(src => src.Urun.Rotalar))
                .ReverseMap();
            CreateMap<AtolyeIsler, UrunSiparisViewModel>()
            .ForMember(dest => dest.UrunAdi, opt => opt.MapFrom(src => src.Urun.UrunAdi))
            .ReverseMap();
            CreateMap<Urun, UrunHammaddeViewModel>().ReverseMap();
            CreateMap<Hammadde, UrunHammaddeViewModel>()
            .ForMember(dest => dest.Hammaddeler, opt => opt.MapFrom(src => new List<Hammadde> { src })).ReverseMap();
            CreateMap<Urun, UrunRotaViewModel>().ReverseMap();
            CreateMap<Atolye, UrunRotaViewModel>().ReverseMap();
            CreateMap<Rota, UrunRotaViewModel>()
            .ForMember(dest => dest.Rotalar, opt => opt.MapFrom(src => new List<Rota> { src })).ReverseMap();
            CreateMap<Hammadde, HammaddePlanViewModel>()
            .ForMember(dest => dest.UrunAdi, opt => opt.MapFrom(src => src.Urun.UrunAdi))
            .ForMember(dest => dest.KategoriAdi, opt => opt.MapFrom(src => src.Kategori.KategoriAdi)).ReverseMap();
            CreateMap<HammaddeSiparis, HammaddeSiparisViewModel>()
                .ForMember(dest => dest.HammaddeAdi, opt => opt.Ignore())
                .ForMember(dest => dest.TedarikciAdi, opt => opt.Ignore()).ReverseMap();
            CreateMap<UrunSiparis, UrunSiparisViewModel>().ReverseMap();
        }



    }
}

