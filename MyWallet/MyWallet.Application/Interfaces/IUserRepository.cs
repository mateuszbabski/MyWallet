using MyWallet.Application.Authentication.AccountDetails;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<int> RegisterNewUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);

        Task UpdateUserPasswordAsync(User user);
    }
}
