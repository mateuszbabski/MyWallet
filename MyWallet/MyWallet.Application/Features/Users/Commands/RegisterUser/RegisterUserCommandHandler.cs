//using AutoMapper;
//using MediatR;
//using MyWallet.Application.Authentication;

//using MyWallet.Application.Interfaces;
//using MyWallet.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyWallet.Application.Features.Users.Commands.RegisterUser
//{
//    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthenticationResponse>
//    {

//        private readonly IAuthenticationService _authentication;


//        public RegisterUserCommandHandler(IAuthenticationService authentication)
//        {
//            _authentication = authentication;
//        }



//        public async Task<AuthenticationResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
//        {
//            return await _authentication.RegisterAsync(request);
//        }
//    }
//}

