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

        public UpdateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository.GetBudgetByIdAsync(request.Id);
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
        

            
