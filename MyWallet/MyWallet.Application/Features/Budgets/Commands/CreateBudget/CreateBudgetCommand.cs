using MediatR;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Commands.CreateBudget
{
    public class CreateBudgetCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        //public int UserId { get; set; }
    }
}

