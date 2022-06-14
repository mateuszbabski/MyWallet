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
        Task<PaginatedList<Transaction>> GetTransactionsByBudgetIdAsync(int userId, int budgetId, int pageNumber, int pageSize);
        Task<PaginatedList<Transaction>> GetTransactionsBySearchAsync(string searchPhrase, int userId, int pageNumber, int pageSize);

    }
}
        
        
        
