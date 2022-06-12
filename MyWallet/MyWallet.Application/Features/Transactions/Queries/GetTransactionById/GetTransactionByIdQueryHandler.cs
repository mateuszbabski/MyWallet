using AutoMapper;
using MediatR;
using MyWallet.Application.Exceptions;
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
        private readonly ICurrentUserService _userService;

        public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository, 
            IMapper mapper, ICurrentUserService userService)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<TransactionViewModel> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId;
            var transaction = await _transactionRepository.GetTransactionByIdAsync(request.Id, userId);
            if(transaction is null)
                throw new NotFoundException("Transaction not found");

            return _mapper.Map<TransactionViewModel>(transaction);
        }
    }
}
            
            
