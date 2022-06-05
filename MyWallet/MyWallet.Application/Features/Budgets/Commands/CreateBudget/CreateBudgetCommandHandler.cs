using AutoMapper;
using MediatR;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Commands.CreateBudget
{
    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, CreateBudgetCommandResponse>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public CreateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public async Task<CreateBudgetCommandResponse> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBudgetCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateBudgetCommandResponse(validatorResult);

            var budget = _mapper.Map<Budget>(request);
            await _budgetRepository.AddBudgetAsync(budget);

            return new CreateBudgetCommandResponse(budget.Id);
        }
    }
}

