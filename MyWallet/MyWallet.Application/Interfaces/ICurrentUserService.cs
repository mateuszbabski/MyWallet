using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Interfaces
{
    public interface ICurrentUserService
    {
        ClaimsPrincipal User { get; }
        int GetUserId { get; }
    }
}
