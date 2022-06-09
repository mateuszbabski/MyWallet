using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; set; }
    }
}
