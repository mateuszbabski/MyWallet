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

namespace MyWallet.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        private readonly IBudgetRepository _budgetRepository;

        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository,
            IMapper mapper,
            ICurrentUserService userService, 
            IBudgetRepository budgetRepository)
        {
            
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _userService = userService;
            _budgetRepository = budgetRepository;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId;
            var budget = await _budgetRepository.GetBudgetByIdAsync(request.BudgetId, userId);

            var transaction = await _transactionRepository.GetTransactionByIdAsync(request.Id, userId);
            if (transaction == null || budget.CreatedById != userId)
                throw new NotFoundException("Transaction not found");

            transaction.BudgetId = request.BudgetId;
            transaction.Type = request.Type;
            transaction.Category = request.Category;
            transaction.Value = request.Value;
            transaction.Description = request.Description;
            transaction.TransactionDate = request.TransactionDate;
            
            var transactionDto = _mapper.Map<Transaction>(transaction);

            await _transactionRepository.UpdateTransactionAsync(transactionDto);

            return Unit.Value;
        }
    }
}
            

       

            

