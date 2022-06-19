using MediatR;
using MyWallet.Application.Authentication;

using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthenticationResponse>
    {
        private readonly IAuthenticationService _authentication;

        public LoginUserCommandHandler(IAuthenticationService authentication)
        {
            _authentication = authentication;
        }
        public async Task<AuthenticationResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _authentication.LoginAsync(request);
        }

        public Task Handle(LoginUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
