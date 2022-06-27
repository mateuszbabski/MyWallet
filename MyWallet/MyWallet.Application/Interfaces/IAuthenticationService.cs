
using MyWallet.Application.Authentication;
using MyWallet.Application.Authentication.LoginUser;
using MyWallet.Application.Authentication.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> RegisterAsync(RegisterUserRequest request);
        Task<AuthenticationResponse> LoginAsync(LoginUserRequest request);
        
    }
}
