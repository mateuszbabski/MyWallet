using MediatR;
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
        private readonly IBudgetRepository _budgetRepository;
        private readonly ITransactionRepository _transactionRepository;

        public DeleteTransactionCommandHandler(IBudgetRepository budgetRepository, ITransactionRepository transactionRepository)
        {
            _budgetRepository = budgetRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository.GetByIdAsync(request.BudgetId);
            //var transaction = await _transactionRepository.GetByIdAsync(budget, request.Id);
            var transaction = await _transactionRepository.GetByIdAsync(request.Id);

            await _transactionRepository.DeleteAsync(transaction);
            return Unit.Value;
        }
    }
}
