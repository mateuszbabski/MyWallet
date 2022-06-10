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

namespace MyWallet.Application.Features.Budgets.Queries.GetBudgetById
{
    public class GetBudgetByIdQueryHandler : IRequestHandler<GetBudgetByIdQuery, BudgetViewModel>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public GetBudgetByIdQueryHandler(IBudgetRepository budgetRepository, IMapper mapper, ICurrentUserService userService)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<BudgetViewModel> Handle(GetBudgetByIdQuery request, CancellationToken cancellationToken)
        {
            var creatorId = _userService.GetUserId;
            var budget = await _budgetRepository.GetBudgetByIdAsync(request.Id, creatorId);
            if (budget == null)
                throw new NotFoundException("Budget not found");

            return _mapper.Map<BudgetViewModel>(budget);
        }
    }
}

