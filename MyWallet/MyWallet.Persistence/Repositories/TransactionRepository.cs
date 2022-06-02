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

        public TransactionRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        //private readonly ApplicationDbContext _dbContext;

        //public TransactionRepository(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public async Task<IEnumerable<TransactionInListViewModel>> GetAllTransactionsAsync(Budget budget)
        //{
        //    return await _dbContext
        //        .Set<TransactionInListViewModel>()
        //        .Where(x => x.BudgetId == budget.Id)
        //        .ToListAsync();
        //}

        //public async Task<TransactionViewModel> GetTransactionByIdAsync(Budget budget, int id)
        //{
        //    return await _dbContext
        //        .Set<TransactionViewModel>()
        //        .Where(x => x.BudgetId == budget.Id)
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task UpdateTransactionAsync(Transaction transaction)
        //{

        //    _dbContext.Entry(transaction).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task DeleteTransactionAsync(TransactionViewModel transaction)
        //{
        //    _dbContext.Set<TransactionViewModel>().Remove(transaction);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task<int> AddTransactionAsync(Transaction transaction)
        //{
        //    await _dbContext.Set<Transaction>().AddAsync(transaction);
        //    await _dbContext.SaveChangesAsync();

        //    return transaction.Id;
        //}
    }
}
