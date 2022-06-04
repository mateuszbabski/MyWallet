using MediatR;
using MyWallet.Application.Enums;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetTransactionsBySearch
{
    public class GetTransactionsBySearchQuery : IRequest<PaginatedList<TransactionInListViewModel>>
    {
        public int BudgetId { get; set; }
        public string SearchPhrase { get; set; } 

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}

        

        
