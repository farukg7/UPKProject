using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Kullanıcı adı gilrilmesi zorunludur.")]
        public String? UserName { get; init; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-Mail gilrilmesi zorunludur.")]        
        public String? Email { get; init; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefon numarası gilrilmesi zorunludur.")]
        public String? PhoneNumber { get; init; }

        public HashSet<String> Roles { get; set; } = new HashSet<string>();
    }
}
