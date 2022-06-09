using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email has to be put in correct format");

            RuleFor(p => p.Password)
                .MinimumLength(6)
                .WithMessage("Password is too short");


            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);

            //RuleFor(x => x.Email)
            //    .Custom((value, context) =>
            //    {
            //        var emailInUse = dbContext.Users.Any(e => e.Email == value);
            //        if (emailInUse)
            //        {
            //            context.AddFailure("Email is taken");
            //        }
            //    });
        }
    }
}
