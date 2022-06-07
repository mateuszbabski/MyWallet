﻿using AutoMapper;
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
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, CreateTransactionCommandResponse>
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

        public async Task<CreateTransactionCommandResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTransactionCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateTransactionCommandResponse(validatorResult);

            var transaction = _mapper.Map<Transaction>(request);
            transaction.BudgetId = request.BudgetId;

            await _transactionRepository.AddTransactionAsync(transaction);

            return new CreateTransactionCommandResponse(transaction.Id);
            
        }
    }
}
            

