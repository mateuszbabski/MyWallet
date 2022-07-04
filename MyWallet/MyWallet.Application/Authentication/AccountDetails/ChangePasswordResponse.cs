using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Authentication.AccountDetails
{
    public class ChangePasswordResponse
    {
        public bool IsSuccess { get; set; }
        public string Password { get; set; }
        public string Errors { get; set; }
       
    }
}
