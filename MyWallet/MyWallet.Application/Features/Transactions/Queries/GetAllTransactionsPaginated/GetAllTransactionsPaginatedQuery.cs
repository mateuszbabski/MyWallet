//using MediatR;
//using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
//using MyWallet.Application.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyWallet.Application.Features.Transactions.Queries.GetAllTransactionsPaginated
//{
//    public class GetAllTransactionsPaginatedQuery : IRequest<PaginatedList<TransactionInListViewModel>>
//    {
//        public int BudgetId { get; set; }

//        const int maxPageSize = 25;
//        public int PageNumber { get; set; } = 1;

//        private int _pageSize = 5;

//        public int PageSize
//        {
//            get { return _pageSize; }
//            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
//        }

//    }
//}
