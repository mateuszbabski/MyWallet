using MediatR;
using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Queries.GetAllBudgets
{
    public record GetAllBudgetsQuery : IRequest<IEnumerable<BudgetInListViewModel>>
    {
        public int CreatedById { get; set; }
    }
}
