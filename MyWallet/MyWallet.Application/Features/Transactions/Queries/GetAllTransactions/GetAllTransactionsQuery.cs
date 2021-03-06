using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<TransactionInListViewModel>>
    {
        public int BudgetId { get; set; }
    }
}
