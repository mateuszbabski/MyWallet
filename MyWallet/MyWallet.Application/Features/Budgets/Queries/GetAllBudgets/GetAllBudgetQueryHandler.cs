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
        private readonly ICurrentUserService _userService;
        

        public GetAllBudgetQueryHandler(IMapper mapper, 
            IBudgetRepository budgetRepository, 
            ICurrentUserService userService)
        {
            _mapper = mapper;
            _budgetRepository = budgetRepository;
            _userService = userService;
        }
            

        public async Task<IEnumerable<BudgetInListViewModel>> Handle(GetAllBudgetsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId;
            var allBudgets = await _budgetRepository.GetAllBudgetsAsync(userId);
            if (allBudgets == null)
                throw new NotFoundException("Budgets not found");
               
            return _mapper.Map<List<BudgetInListViewModel>>(allBudgets);
        }
    }
}
            

