using FluentValidation;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Commands.CreateBudget
{
    public class CreateBudgetCommandValidator : AbstractValidator<CreateBudgetCommand>
    {
        private readonly Interfaces.IBudgetRepository _budgetRepository;

        public CreateBudgetCommandValidator(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;

            RuleFor(p => p.Name)
                .NotEmpty();
            RuleFor(p => p.Description)
                .MaximumLength(100);
        }
    }
}
