using MyWallet.Application.Authentication.AccountDetails;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Interfaces
{
    public interface IAccountServices
    {
        Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordRequest request);
    }
}
