using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Interfaces
{
    public interface IBudgetRepository : IAsyncRepository<Budget>
    {
        
        //Task<IEnumerable<BudgetInListViewModel>> GetAllAsync();
        Task<Budget> GetBudgetByIdAsync(int id);
        //Task<int> AddAsync(Budget budget);
        //Task UpdateAsync(Budget budget);
        //Task DeleteAsync(BudgetViewModel budget);

        //Task<Budget> GetBudgetByIdAsync(int id);
    }
}
        

