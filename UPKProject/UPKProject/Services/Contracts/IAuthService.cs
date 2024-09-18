using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> GelAllUsers();
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task<IdentityUser> GetOneUser(string userName);
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);       //kullanıcı bilgilerini okurken rol bilgilerini de getirmemiz gerekiyor normalde userbilgilerini alıyoruz fakat rol bilgilerini alamıyoruz dolayısıyla ikisini birlikte alabilmek için metodu oluşturuyoruz    
        Task Update(UserDtoForUpdate userDto);
        Task<IdentityResult> ResetPassword(ResetPasswordDto userDto);
        Task<IdentityResult> DeleteOneUser(string userName);
    }
}
