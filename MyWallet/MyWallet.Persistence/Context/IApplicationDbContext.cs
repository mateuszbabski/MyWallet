using Microsoft.EntityFrameworkCore;
using MyWallet.Domain.Entities;

namespace MyWallet.Persistence.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Budget> Budgets { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}