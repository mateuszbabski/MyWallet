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
        //Task<IEnumerable<TransactionInListViewModel>> GetAllTransactionsAsync(Budget budget);
        //Task<TransactionViewModel> GetTransactionByIdAsync(Budget budget, int id);
        //Task DeleteTransactionAsync(TransactionViewModel transaction);
        //Task<int> AddTransactionAsync(Transaction transaction);
        //Task UpdateTransactionAsync(Transaction transaction);

    }
}
        
        
