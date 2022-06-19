using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyWallet.Application.Interfaces
{
    public interface IBudgetRepository : IAsyncRepository<Budget>
    {
        
        Task<IEnumerable<Budget>> GetAllBudgetsAsync(int userId);
        Task<Budget> GetBudgetByIdAsync(int id, int userId);
        Task<int> AddBudgetAsync(Budget budget);
        Task UpdateBudgetAsync(Budget budget);
        Task DeleteBudgetAsync(Budget budget);


    }
}
        

