using MyWallet.Application.Features.Users.Commands.RegisterUser;
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
    }
}
