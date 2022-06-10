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
        private readonly ICurrentUserService _userService;

        public CreateBudgetCommandHandler(IBudgetRepository budgetRepository, IMapper mapper, ICurrentUserService userService)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<int> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = _mapper.Map<Budget>(request);
            budget.CreatedById = _userService.GetUserId;

            await _budgetRepository.AddBudgetAsync(budget);

            return budget.Id;
        }
    }
}

