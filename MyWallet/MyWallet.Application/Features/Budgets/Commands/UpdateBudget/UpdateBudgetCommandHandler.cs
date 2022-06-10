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


namespace MyWallet.Application.Features.Budgets.Commands.UpdateBudget
{
    public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public UpdateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper, ICurrentUserService userService)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<Unit> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
        {
            var creatorId = _userService.GetUserId;
            var budget = await _budgetRepository.GetBudgetByIdAsync(request.Id, creatorId);
            if (budget == null)
                throw new NotFoundException("Budget not found");

            budget.Name = request.Name;
            budget.Description = request.Description;

            var newBudget = _mapper.Map<Budget>(budget);
            await _budgetRepository.UpdateBudgetAsync(newBudget);

            return Unit.Value;
        }
    }
}
        

            
