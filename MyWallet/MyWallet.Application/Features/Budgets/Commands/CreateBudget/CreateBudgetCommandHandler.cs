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
    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, int>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;

        public CreateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBudgetCommandValidator(_budgetRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new Exception("Not validated");

            var budget = _mapper.Map<Budget>(request);
            await _budgetRepository.AddAsync(budget);

            return budget.Id;
        }
    }
}

