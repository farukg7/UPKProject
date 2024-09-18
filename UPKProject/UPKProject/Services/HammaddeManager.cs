using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.Models.ViewModel;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HammaddeManager : IHammaddeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public HammaddeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void DeleteOneHammadde(int id)
        {
            Hammadde hammadde = GetOneHammadde(id, false);
            if(hammadde is not null)
            {
                _manager.Hammadde.DeleteOneHammadde(hammadde);
                _manager.Save();
            }
        }

        public IEnumerable<Hammadde> GetAllHammadeler(bool trackChanges)
        {
            return _manager.Hammadde.GetAllHammadeler(trackChanges);
        }

        public Hammadde? GetOneHammadde(int id, bool trackChanges)
        {
            var hammadde=_manager.Hammadde.GetOneHammadde(id, trackChanges);
            if (hammadde is null)
                throw new Exception("Aradığınız hammadde bulunamadı.");
            return hammadde;
        }

        public void CreateOneHammadde(HammaddeDtoForInsertion hammaddeDto)
        {
            Hammadde hammadde=_mapper.Map<Hammadde>(hammaddeDto);
            _manager.Hammadde.Create(hammadde);
            _manager.Save();
        }

        public void UpdateOneHammadde(HammaddeDtoForUpdate hammaddeDto)
        {
            //var entity = _manager.Hammadde.GetOneHammadde(hammaddeDto.Id, true);
            //entity.Adi = hammaddeDto.Adi;
            //entity.AlisFiyati = hammaddeDto.AlisFiyati;
            //entity.KategoriId = hammaddeDto.KategoriId;
            var entity = _mapper.Map<Hammadde>(hammaddeDto);
            _manager.Hammadde.UpdateOneHammade(entity);
            _manager.Save();
        }

        public HammaddeDtoForUpdate GetOneHammaddeForUpdate(int id, bool trackChanges)
        {
            var hammadde=GetOneHammadde(id,trackChanges);
            var hammaddeDto = _mapper.Map<HammaddeDtoForUpdate>(hammadde);
            return hammaddeDto;
        }

        public IEnumerable<Hammadde> GetVitrinHamaddeler(bool trackChanges)
        {
            var hammadde = _manager.Hammadde.GetVitrinHamaddeler(trackChanges);
            return hammadde;
        }

        public IEnumerable<Hammadde> GetAllHammaddelerWithDetails(HammaddeRequestParameters p)
        {
            return _manager.Hammadde.GetAllHammaddelerWithDetails(p);
        }

        public IEnumerable<Hammadde> GetLastestHammadeler(int n, bool trackChanges)
        {
            return _manager.Hammadde.FindAll(trackChanges).OrderByDescending(hmd => hmd.HammaddeId).Take(n);
        }

        public IEnumerable<Hammadde> GetAllHammaddelerByUrun(int id, bool trackChanges)
        {
            return _manager.Hammadde.GetAllHammaddelerByUrun(id, trackChanges).ToList();
        }

        public void UpdateHammaddeler(IEnumerable<Hammadde> hammaddeler)
        {
            _manager.Hammadde.UpdateHammaddeler(hammaddeler);
        }

        public void UpdateOneHammaddeUrun(Hammadde hammadde)
        {           
            _manager.Hammadde.UpdateOneHammade(hammadde);
            _manager.Save();
        }

        public IEnumerable<HammaddePlanViewModel> GetAllHammaddePlan(bool trackChanges)
        {
            var hammaddes=_manager.Hammadde.GetAllHammadeler(trackChanges).ToList();
            var hammaddeplan = _mapper.Map<IEnumerable<HammaddePlanViewModel>>(hammaddes);
            return hammaddeplan;
        }
    }
}
