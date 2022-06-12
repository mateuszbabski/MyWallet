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

namespace MyWallet.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        private readonly IBudgetRepository _budgetRepository;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, 
            IMapper mapper, 
            ICurrentUserService userService, IBudgetRepository budgetRepository)
        {
            
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _userService = userService;
            _budgetRepository = budgetRepository;
        }

        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId;
            var budget = await _budgetRepository.GetBudgetByIdAsync(request.BudgetId, userId);

            var transaction = _mapper.Map<Transaction>(request);
            transaction.BudgetId = request.BudgetId;
            transaction.CreatedById = _userService.GetUserId;

            if(budget.CreatedById != userId)
            {
                throw new BadRequestException("You cant add transaction to this budget");
            }

            await _transactionRepository.AddTransactionAsync(transaction);

            return transaction.Id;
            
        }
    }
}
            

            

            

