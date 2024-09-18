using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class HammaddeRepositoryExtension
    {
        public static IQueryable<Hammadde> FilteredByKategoriId(this IQueryable<Hammadde> hammaddeler, int? kategoriId)
        {
            if (kategoriId is null)
                return hammaddeler;
            else
                return hammaddeler.Where(hmd => hmd.KategoriId.Equals(kategoriId));
        }

        public static IQueryable<Hammadde> FilteredBySearchTerm(this IQueryable<Hammadde> hammaddeler, String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return hammaddeler;
            else
                return hammaddeler.Where(hmd => hmd.HammaddeAdi.ToLower().Contains(searchTerm.ToLower()));
        }

        public static IQueryable<Hammadde> FilteredByPrice(this IQueryable<Hammadde> hammaddeler, int minPrice, int maxPrice, bool isValidPrice)
        {
            if (isValidPrice)
                return hammaddeler.Where(hmd => hmd.AlisFiyati >= minPrice && hmd.AlisFiyati <= maxPrice);
            else
                return hammaddeler;
        }

        public static IQueryable<Hammadde> ToPaginate(this IQueryable<Hammadde> hammaddeler, int pageNumber, int pageSize)
        {
            return hammaddeler
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
