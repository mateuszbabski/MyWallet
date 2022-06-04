using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionById;
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
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task DeleteTransactionAsync(Transaction transaction);
        Task<int> AddTransactionAsync(Transaction transaction);
        Task UpdateTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactionsByBudgetIdAsync(string searchPhrase, int budgetId);
        Task<IEnumerable<Transaction>> GetTransactionsBySearchAsync(string searchPhrase);

    }
}
        
        
