using Microsoft.EntityFrameworkCore;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionById;
using MyWallet.Application.Interfaces;
using MyWallet.Application.Wrappers;
using MyWallet.Domain.Entities;
using MyWallet.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync(int userId)
        {
            return await _dbContext
                .Transactions
                .Where(x => x.CreatedById == userId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(int userId,
                int budgetId,
                DateTime dateFrom,
                DateTime dateTo)
        {
            return await _dbContext
                .Transactions
                .Where(t => t.CreatedById == userId)
                .Where(t => t.BudgetId == budgetId)
                .Where(t => t.TransactionDate > dateFrom)
                .Where(t => t.TransactionDate < dateTo)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsByBudgetIdAsync(int userId, 
                int budgetId)
        {
            return await _dbContext
                .Transactions
                .Where(t => t.CreatedById == userId)
                .Where(t => t.BudgetId == budgetId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsBySearchAsync(int userId, string searchPhrase)
        {
                return await _dbContext
                    .Transactions
                    .Where(u => u.CreatedById == userId)
                    .Where(x => searchPhrase == null
                                                     || (x.Category.ToLower().Contains(searchPhrase.ToLower())
                                                     || x.Type.ToLower().Contains(searchPhrase.ToLower())))
                    .OrderByDescending(t => t.TransactionDate)
                    .ToListAsync();
        }
        public async Task<Transaction> GetTransactionByIdAsync(int id, int userId)
        {
            return await _dbContext
                .Transactions
                .Where(i => i.CreatedById == userId)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(Transaction transaction)
        {
            _dbContext.Transactions.Remove(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddTransactionAsync(Transaction transaction)
        {
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();

            return transaction.Id;
        }
    }
}

            



            
            
            





            









                
                


            

