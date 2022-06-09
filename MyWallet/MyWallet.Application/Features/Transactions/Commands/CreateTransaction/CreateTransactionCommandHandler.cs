using AutoMapper;
using MediatR;
using MyWallet.Application.Exceptions;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {

            var transaction = _mapper.Map<Transaction>(request);
            transaction.BudgetId = request.BudgetId;

            await _transactionRepository.AddTransactionAsync(transaction);

            return transaction.Id;
            
        }
    }
}
            
            

            

