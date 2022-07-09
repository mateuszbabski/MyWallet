using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Queries.GetBudgetById
{
    public class GetBudgetByIdQuery : IRequest<BudgetViewModel>
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
    }
        
}
