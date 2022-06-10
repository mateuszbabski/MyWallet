using Microsoft.EntityFrameworkCore;
using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
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
    public class BudgetRepository : BaseRepository<Budget>, IBudgetRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BudgetRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Budget>> GetAllBudgetsAsync(int creatorId)
        {

            return await _dbContext
                .Budgets
                .Where(i => i.CreatedById == creatorId)
                .Include(t => t.Transactions)
                .ToListAsync();
        }

        public async Task<Budget> GetBudgetByIdAsync(int id, int creatorId)
        {

            return await _dbContext
                .Budgets
                .Where(i => i.CreatedById == creatorId)
                .Include(t => t.Transactions.OrderByDescending(x => x.TransactionDate).Take(5))
                .FirstOrDefaultAsync(x => x.Id == id);
        }
                
        public async Task UpdateBudgetAsync(Budget budget)
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBudgetAsync(Budget budget)
        {
            _dbContext.Budgets.Remove(budget);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddBudgetAsync(Budget budget)
        {
            await _dbContext.Budgets.AddAsync(budget);
            await _dbContext.SaveChangesAsync();

            return budget.Id;
        }

    }
}

            

       


