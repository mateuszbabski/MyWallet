//using AutoMapper;
//using MediatR;
//using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
//using MyWallet.Application.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyWallet.Application.Features.Transactions.Queries.GetAllTransactions
//{
//    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionInListViewModel>>
//    {
//        private readonly ITransactionRepository _transactionRepository;
//        private readonly IBudgetRepository _budgetRepository;
//        private readonly IMapper _mapper;

//        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository, IBudgetRepository budgetRepository, IMapper mapper)
//        {
//            _transactionRepository = transactionRepository;
//            _budgetRepository = budgetRepository;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<TransactionInListViewModel>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
//        {
//            var budget = await _budgetRepository.GetByIdAsync(request.BudgetId);
//            var transactions = await _transactionRepository.GetAllAsync(budget);

//            return _mapper.Map<IEnumerable<TransactionInListViewModel>>(transactions);
//        }
//    }
//}

