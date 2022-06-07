using AutoMapper;
using MediatR;
using MyWallet.Application.Exceptions;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Interfaces;
using MyWallet.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetTransactionsByBudgetId
{
    
        public class GetTransactionsByBudgetIdQueryHandler : IRequestHandler<GetTransactionsByBudgetIdQuery, PaginatedList<TransactionInListViewModel>>
        {
            private readonly ITransactionRepository _transactionRepository;
            private readonly IMapper _mapper;
            

            public GetTransactionsByBudgetIdQueryHandler(ITransactionRepository transactionRepository,
                IMapper mapper)
                
            {
                _transactionRepository = transactionRepository;
                _mapper = mapper;
            }

                
            public async Task<PaginatedList<TransactionInListViewModel>> Handle(GetTransactionsByBudgetIdQuery request,
                CancellationToken cancellationToken)
            {
                var transactions = await _transactionRepository.GetTransactionsByBudgetIdAsync(request.SearchPhrase, request.BudgetId, request.PageNumber, request.PageSize);
                
                var count = transactions.Count();

                var transactionDto = _mapper.Map<List<TransactionInListViewModel>>(transactions);
                var result = new PaginatedList<TransactionInListViewModel>(transactionDto, count, request.PageNumber, request.PageSize);

                return result;
            }
        }
    }

                
                


