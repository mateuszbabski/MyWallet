
using MyWallet.Application.Features.Users.Commands.LoginUser;
using MyWallet.Application.Features.Users.Commands.RegisterUser;
using MyWallet.Application.Features.Users.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> RegisterAsync(RegisterUserCommand request);
        Task<AuthenticationResponse> LoginAsync(LoginUserCommand request);
        
    }
}
