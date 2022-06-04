﻿using AutoMapper;
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
            var budget = await _budgetRepository.GetBudgetByIdAsync(request.BudgetId);
            var transaction = await _transactionRepository.GetTransactionByIdAsync(request.Id);
            
            transaction.BudgetId = request.BudgetId;
            transaction.Type = request.Type;
            transaction.Category = request.Category;
            transaction.Value = request.Value;
            transaction.Description = request.Description;
            transaction.TransactionDate = request.TransactionDate;

            var validator = new UpdateTransactionCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new Exception("Not validated");

            var transactionDto = _mapper.Map<Transaction>(transaction);

            await _transactionRepository.UpdateTransactionAsync(transactionDto);

            return Unit.Value;
        }
    }
}

