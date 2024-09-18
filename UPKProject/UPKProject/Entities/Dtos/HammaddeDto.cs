using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record HammaddeDto
    {
        public int Id { get; set; }
        public string? Adi { get; init; } = string.Empty;
        public decimal? AlisFiyati { get; init; }
        public int? KullanılacakAdet { get; set; }
        public int? KategoriId { get; init; }
        public string? OzetBilgi { get; init; } = string.Empty;
        public String? ResimUrl { get; set; }
    }
}
