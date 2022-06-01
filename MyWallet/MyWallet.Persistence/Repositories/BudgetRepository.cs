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
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BudgetRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BudgetInListViewModel>> GetAllAsync()
        {
            
            return await _dbContext
                .Set<BudgetInListViewModel>()
                .Include(t => t.Transactions)
                .ToListAsync();
        }

        public async Task<BudgetViewModel> GetByIdAsync(int id)
        {

            return await _dbContext
                .Set<BudgetViewModel>()
                .Include(t => t.Transactions)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Budget budget)
        {
            _dbContext.Entry(budget).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(BudgetViewModel budget)
        {
            _dbContext.Set<BudgetViewModel>().Remove(budget);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddAsync(Budget budget)
        {
            await _dbContext.Set<Budget>().AddAsync(budget);
            await _dbContext.SaveChangesAsync();

            return budget.Id;
        }
    }
}
