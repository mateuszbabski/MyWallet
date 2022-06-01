using AutoMapper;
using MediatR;
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
        private readonly IBudgetRepository _budgetRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(IBudgetRepository budgetRepository, ITransactionRepository transactionRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository.GetByIdAsync(request.BudgetId);
            var transaction = await _transactionRepository.GetByIdAsync(budget, request.Id);

            var transactionDto = _mapper.Map<Transaction>(transaction);

            await _transactionRepository.UpdateAsync(transactionDto);

            return Unit.Value;
        }
    }
}
