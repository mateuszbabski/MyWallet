using AutoMapper;
using MediatR;
using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetTransactionById
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionViewModel>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IBudgetRepository _budgetRepository;

        public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository, IMapper mapper, IBudgetRepository budgetRepository)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _budgetRepository = budgetRepository;
        }

        public async Task<TransactionViewModel> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(request.Id);

            return _mapper.Map<TransactionViewModel>(transaction);
        }
    }
}
            
            
