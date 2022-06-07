using AutoMapper;
using MediatR;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionInListViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository, 
            IMapper mapper)
            
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

            
        public async Task<IEnumerable<TransactionInListViewModel>> Handle(GetAllTransactionsQuery request, 
            CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();

            return _mapper.Map<IEnumerable<TransactionInListViewModel>>(transactions);
        }
    }
}
         
            

