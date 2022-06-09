using MediatR;
using MyWallet.Application.Authentication.Responses;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<AuthenticationResponse>
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
    }
}
