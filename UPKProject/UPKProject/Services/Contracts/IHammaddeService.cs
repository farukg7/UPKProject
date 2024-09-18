using Entities.Dtos;
using Entities.Models;
using Entities.Models.ViewModel;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IHammaddeService
    {             
        IEnumerable<Hammadde> GetAllHammadeler(bool trackChanges);
        IEnumerable<HammaddePlanViewModel> GetAllHammaddePlan(bool trackChanges);
        IEnumerable<Hammadde> GetLastestHammadeler(int n, bool trackChanges);
        IEnumerable<Hammadde> GetVitrinHamaddeler(bool trackChanges);
        IEnumerable<Hammadde> GetAllHammaddelerWithDetails(HammaddeRequestParameters p);
        Hammadde? GetOneHammadde(int id, bool trackChanges);
        void CreateOneHammadde(HammaddeDtoForInsertion hammaddeDto);
        void UpdateOneHammadde(HammaddeDtoForUpdate hammaddeDto);
        void UpdateOneHammaddeUrun(Hammadde hammadde);
        void DeleteOneHammadde(int id);
        HammaddeDtoForUpdate GetOneHammaddeForUpdate(int id, bool trackChanges);
        IEnumerable<Hammadde> GetAllHammaddelerByUrun(int id, bool trackChanges);
        void UpdateHammaddeler(IEnumerable<Hammadde> hammaddeler);
    }
}
