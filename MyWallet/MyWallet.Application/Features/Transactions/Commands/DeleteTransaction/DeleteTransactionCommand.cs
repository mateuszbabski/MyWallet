using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommand : IRequest
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
    }
}
