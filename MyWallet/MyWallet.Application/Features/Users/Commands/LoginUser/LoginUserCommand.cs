using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
