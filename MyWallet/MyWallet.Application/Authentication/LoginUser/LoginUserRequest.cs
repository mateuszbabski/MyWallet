using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Authentication.LoginUser
{
    public class LoginUserRequest : IRequest<AuthenticationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
