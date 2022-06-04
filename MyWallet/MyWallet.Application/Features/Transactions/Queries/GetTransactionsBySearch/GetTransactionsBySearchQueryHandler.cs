
using AutoMapper;
using MediatR;
using MyWallet.Application.Enums;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Interfaces;
using MyWallet.Application.Wrappers;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetTransactionsBySearch
{
    public class GetTransactionsBySearchQueryHandler : IRequestHandler<GetTransactionsBySearchQuery, PaginatedList<TransactionInListViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;
        
        public GetTransactionsBySearchQueryHandler(ITransactionRepository transactionRepository,
            IBudgetRepository budgetRepository,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<TransactionInListViewModel>> Handle(GetTransactionsBySearchQuery request,
            CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetTransactionsBySearchAsync(request.SearchPhrase, request.PageNumber, request.PageSize);
            //var transactionsPaged = transactions
            //    .Skip((request.PageNumber - 1) * request.PageSize)
            //    .Take(request.PageSize)
            //    .ToList();

            var count = transactions.Count();

            var transactionDto = _mapper.Map<List<TransactionInListViewModel>>(transactions);
            var result = new PaginatedList<TransactionInListViewModel>(transactionDto, count, request.PageNumber, request.PageSize);

            return result;
        }
    }
}
            






            

