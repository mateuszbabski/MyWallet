using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Authentication.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email has to be put in correct format");

            RuleFor(p => p.Password)
                .MinimumLength(6)
                .WithMessage("Password is too short");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password and confirm password are not the same");
        }
    }
}
