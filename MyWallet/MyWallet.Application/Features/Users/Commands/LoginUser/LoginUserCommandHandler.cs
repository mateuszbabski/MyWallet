using MediatR;
using MyWallet.Application.Authentication.Responses;
using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequest<LoginUserCommand>
    {
        private readonly IAuthentication _authentication;

        public LoginUserCommandHandler(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        public async Task<AuthenticationResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _authentication.LoginAsync(request);
        }
    }
}
