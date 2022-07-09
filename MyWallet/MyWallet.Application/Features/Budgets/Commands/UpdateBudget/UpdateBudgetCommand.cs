using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Commands.UpdateBudget
{
    public class UpdateBudgetCommand : IRequest
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
        
        
