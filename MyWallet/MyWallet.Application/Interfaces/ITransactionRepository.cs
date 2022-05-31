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
    public interface ITransactionRepository
    {
        //Task<int> Create(CreateTransactionModel dto, int budgetId);
        //Task<Transaction> Delete(int id, int budgetId);
        //Task<PagedList<TransactionModel>> GetAll(int budgetId, RequestParams request);
        //Task<TransactionModel> GetById(int id, int budgetId);
        //Task<int> Update(UpdateTransactionModel dto, int id, int budgetId);
        //Task<Budget> GetBudgetById(int budgetId);
        
        Task<IEnumerable<TransactionInListViewModel>> GetAllAsync(BudgetViewModel budget);
        Task<TransactionViewModel> GetByIdAsync(BudgetViewModel budget, int id);
        Task DeleteAsync(TransactionViewModel transaction);
        Task<int> AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
    }
}
