using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Commands.UpdateBudget
{
    public class UpdateBudgetCommandValidator : AbstractValidator<UpdateBudgetCommand>
    {
        public UpdateBudgetCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name cant be empty");
            RuleFor(p => p.Description)
                .MaximumLength(100);
        }
    }
}
