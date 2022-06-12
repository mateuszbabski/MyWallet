using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MyWallet.Application.Features.Users.Queries;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;
using MyWallet.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserRepository(ApplicationDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> RegisterNewUserAsync(User user)
        {
            
            var newUser = new User()
            {
                FirstName = user.FirstName,
                Email = user.Email,
                Password = user.Password
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, user.Password);
            newUser.PasswordHash = hashedPassword;

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser.Id;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext
                .Users
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext
                .Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}


                
