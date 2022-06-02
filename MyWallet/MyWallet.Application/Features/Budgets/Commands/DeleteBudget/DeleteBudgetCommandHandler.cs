﻿using AutoMapper;
using MediatR;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Commands.DeleteBudget
{
    public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public DeleteBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository.GetBudgetByIdAsync(request.Id);

            await _budgetRepository.DeleteBudgetAsync(budget);
            return Unit.Value;
        }
    }
}
            
            
