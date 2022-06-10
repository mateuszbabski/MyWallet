﻿using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
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
        
        Task<IEnumerable<Budget>> GetAllBudgetsAsync(int creatorId);
        Task<Budget> GetBudgetByIdAsync(int id, int creatorId);
        Task<int> AddBudgetAsync(Budget budget);
        Task UpdateBudgetAsync(Budget budget);
        Task DeleteBudgetAsync(Budget budget);


    }
}
        

