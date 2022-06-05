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

namespace MyWallet.Application.Features.Budgets.Queries.GetAllBudgets
{
    public class GetAllBudgetQueryHandler : IRequestHandler<GetAllBudgetsQuery, IEnumerable<BudgetInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IBudgetRepository _budgetRepository;

        public GetAllBudgetQueryHandler(IMapper mapper, IBudgetRepository budgetRepository)
        {
            _mapper = mapper;
            _budgetRepository = budgetRepository;
        }

        public async Task<IEnumerable<BudgetInListViewModel>> Handle(GetAllBudgetsQuery request, CancellationToken cancellationToken)
        {
            var allBudgets = await _budgetRepository.GetAllBudgetsAsync();
            if (allBudgets == null)
                throw new NotFoundException("Budgets not found");

            return _mapper.Map<List<BudgetInListViewModel>>(allBudgets);
        }
    }
}

