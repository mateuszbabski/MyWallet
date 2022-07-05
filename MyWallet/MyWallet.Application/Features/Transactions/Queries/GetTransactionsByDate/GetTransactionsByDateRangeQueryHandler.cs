using AutoMapper;
using MediatR;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Interfaces;
using MyWallet.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetTransactionsByDate
{
    public class GetTransactionsByDateRangeQueryHandler : IRequestHandler<GetTransactionsByDateRangeQuery, PaginatedList<TransactionInListViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public GetTransactionsByDateRangeQueryHandler(ITransactionRepository transactionRepository,
                IMapper mapper,
                ICurrentUserService userService)

        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _userService = userService;
        }


        public async Task<PaginatedList<TransactionInListViewModel>> Handle(GetTransactionsByDateRangeQuery request,
            CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId;

            var transactions = await _transactionRepository.GetTransactionsByDateRangeAsync(userId, 
                request.BudgetId,
                request.DateFrom, 
                request.DateTo);


            var paginatedTransactions = transactions
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var transactionDto = _mapper.Map<List<TransactionInListViewModel>>(paginatedTransactions);

            var result = new PaginatedList<TransactionInListViewModel>(transactionDto, transactions.Count(), request.PageNumber, request.PageSize);

            return result;
        }

    }
}
