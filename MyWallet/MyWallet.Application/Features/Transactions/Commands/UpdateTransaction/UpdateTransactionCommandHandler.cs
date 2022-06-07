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

namespace MyWallet.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(request.Id);
            if (transaction == null)
                throw new NotFoundException("Transaction not found");

            transaction.BudgetId = request.BudgetId;
            transaction.Type = request.Type;
            transaction.Category = request.Category;
            transaction.Value = request.Value;
            transaction.Description = request.Description;
            transaction.TransactionDate = request.TransactionDate;

            var validator = new UpdateTransactionCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new ValidationException();

            var transactionDto = _mapper.Map<Transaction>(transaction);

            await _transactionRepository.UpdateTransactionAsync(transactionDto);

            return Unit.Value;
        }
    }
}
            

