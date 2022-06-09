using MediatR;
using MyWallet.Application.Exceptions;
using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        
        private readonly ITransactionRepository _transactionRepository;

        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(request.Id);
            if (transaction == null)
                throw new NotFoundException("Transaction not found");

            await _transactionRepository.DeleteTransactionAsync(transaction);
            return Unit.Value;
        }
    }
}
            
            
