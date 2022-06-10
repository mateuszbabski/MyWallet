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

namespace MyWallet.Application.Features.Budgets.Commands.DeleteBudget
{
    public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly ICurrentUserService _userService;

        public DeleteBudgetCommandHandler(IBudgetRepository budgetRepository, ICurrentUserService userService)
        {
            _budgetRepository = budgetRepository;
            _userService = userService;
        }

        public async Task<Unit> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
        {
            var creatorId =  _userService.GetUserId;
            var budget = await _budgetRepository.GetBudgetByIdAsync(request.Id, creatorId);
            if (budget == null)
                throw new NotFoundException("Budget not found");

            await _budgetRepository.DeleteBudgetAsync(budget);
            return Unit.Value;
        }
    }
}
            
            
