using Entities.Models;
using Entities.Models.ViewModel;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UretimPlanlamaKontrol.Repositories;

namespace Repositories
{
    public sealed class HammaddeRepository : RepositoryBase<Hammadde>, IHammaddeRepository
    {
        public HammaddeRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Hammadde> GetAllHammadeler(bool trackChanges)
        {
            return trackChanges
                ? _context.Hammaddeler.Include(h => h.Urun).Include(h => h.Kategori)
                : _context.Hammaddeler.Include(h => h.Urun).Include(h => h.Kategori).AsNoTracking();
        }
    
        public Hammadde? GetOneHammadde(int id, bool trackChanges)
        {
            return FindbyCondition(p => p.HammaddeId.Equals(id), trackChanges);
        }

        public void CreateOneHammadde(Hammadde hammadde)=>Create(hammadde);

        public void DeleteOneHammadde(Hammadde hammadde)=>Remove(hammadde);

        public void UpdateOneHammade(Hammadde hammadde) => Update(hammadde);

        public IQueryable<Hammadde> GetVitrinHamaddeler(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .Where(p=>p.Vitrin.Equals(true));
        }

        public IQueryable<Hammadde> GetAllHammaddelerWithDetails(HammaddeRequestParameters p)
        {
            return _context
                .Hammaddeler
                .FilteredByKategoriId(p.KategoriId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice)
                .ToPaginate(p.PageNumber, p.PageSize);
               

            //extension metotla aşağıdaki logici genişleterek kullandık

            //return p.KategoriId is null
            //    ? _context.Hammaddeler.Include(hmd => hmd.Kategori)
            //    : _context.Hammaddeler.Include(hmd => hmd.Kategori).Where(hmd => hmd.KategoriId.Equals(p.KategoriId));
        }

        public List<Hammadde> GetAllHammaddelerByUrun(int id, bool trackChanges)
        {
            return trackChanges
                ? _context.Hammaddeler.Where(h => h.UrunId.Equals(id)).ToList()
                : _context.Hammaddeler.Where(h => h.UrunId.Equals(id)).AsNoTracking().ToList();
        }

        public void UpdateHammaddeler(IEnumerable<Hammadde> hammaddeler)
        {
            foreach(var hmd  in hammaddeler)
            {
                _context.Hammaddeler.Update(hmd);
            }
            _context.SaveChanges();
        }

    }
}
