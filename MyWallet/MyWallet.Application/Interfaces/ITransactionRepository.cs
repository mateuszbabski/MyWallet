using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionById;
using MyWallet.Application.Wrappers;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Interfaces
{
    public interface ITransactionRepository : IAsyncRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync(int userId);
        Task<Transaction> GetTransactionByIdAsync(int id, int userId);
        Task DeleteTransactionAsync(Transaction transaction);
        Task<int> AddTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactionsByBudgetIdAsync(int userId, int budgetId);
        Task<IEnumerable<Transaction>> GetTransactionsBySearchAsync(int userId, string searchPhrase);
        Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(int userId, int budgetId, DateTime dateFrom, DateTime dateTo);

    }
}
        
        
        
