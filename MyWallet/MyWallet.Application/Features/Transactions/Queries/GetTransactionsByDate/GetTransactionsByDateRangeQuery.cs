using MediatR;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetTransactionsByDate
{
    public class GetTransactionsByDateRangeQuery : IRequest<PaginatedList<TransactionInListViewModel>>
    {
        public int BudgetId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
