using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetTransactionById
{
    public class GetTransactionByIdQuery : IRequest<TransactionViewModel>
    {
        public int Id { get; set; }
    }
}
