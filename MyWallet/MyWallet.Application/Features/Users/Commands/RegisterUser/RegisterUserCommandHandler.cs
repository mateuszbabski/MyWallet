using AutoMapper;
using MediatR;
using MyWallet.Application.Authentication.Responses;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthenticationResponse>
    {
       
        private readonly IAuthentication _authentication;


        public RegisterUserCommandHandler(IAuthentication authentication)
        {
            _authentication = authentication;
        }

            

        public async Task<AuthenticationResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _authentication.RegisterAsync(request);
        }
    }
}

