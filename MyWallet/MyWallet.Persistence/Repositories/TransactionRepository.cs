using Microsoft.EntityFrameworkCore;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionById;
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
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _dbContext
                .Transactions
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<Transaction>> GetPaginatedTransactionsAsync()
        {
            return await _dbContext
                .Transactions
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
                
        }
        public async Task<IEnumerable<Transaction>> GetTransactionsBySearchAsync(string searchPhrase)
        {
            if (!string.IsNullOrEmpty(searchPhrase))
            {
                return await _dbContext
                    .Transactions
                    .Where(x => searchPhrase == null
                                                     || (x.Category.ToLower().Contains(searchPhrase.ToLower())
                                                     || x.Type.ToLower().Contains(searchPhrase.ToLower())))
                    .OrderByDescending(t => t.TransactionDate)
                    .ToListAsync();
            }
            return await _dbContext
                .Transactions
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
            //if(searchPhrase == null)
            //{
            //    return await _dbContext
            //    .Transactions
            //    .OrderByDescending(t => t.TransactionDate)
            //    .ToListAsync();
            //}
            //else
            //{
            //    return await _dbContext
            //        .Transactions
            //        .Where(x => searchPhrase == null
            //                                         || (x.Category.ToLower().Contains(searchPhrase.ToLower())
            //                                         || x.Type.ToLower().Contains(searchPhrase.ToLower())))
            //        .OrderByDescending(t => t.TransactionDate)
            //        .ToListAsync();
            //}
        }
        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _dbContext
                .Transactions
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
            await _dbContext.Set<Transaction>().AddAsync(transaction);
            await _dbContext.SaveChangesAsync();

            return transaction.Id;
        }
    }
}




                
                


            

