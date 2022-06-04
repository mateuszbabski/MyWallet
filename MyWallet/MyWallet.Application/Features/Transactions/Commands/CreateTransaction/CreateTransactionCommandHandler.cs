using AutoMapper;
using MediatR;
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
        private readonly IBudgetRepository _budgetRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(IBudgetRepository budgetRepository, ITransactionRepository transactionRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository.GetBudgetByIdAsync(request.BudgetId);

            var validator = new CreateTransactionCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new Exception("Not validated");

            var transaction = _mapper.Map<Transaction>(request);
            transaction.BudgetId = budget.Id;

            await _transactionRepository.AddTransactionAsync(transaction);

            return transaction.Id;
            
        }
    }
}
