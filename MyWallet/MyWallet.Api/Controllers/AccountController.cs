using MediatR;

using Microsoft.AspNetCore.Mvc;

using MyWallet.Application.Features.Users.Commands.LoginUser;
using MyWallet.Application.Features.Users.Commands.RegisterUser;
using MyWallet.Application.Features.Users.Queries.GetUserById;
using MyWallet.Application.Interfaces;

namespace MyWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpPost("login")]
        public async Task<ActionResult<int>> LoginUser([FromBody] LoginUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<int>> RegisterNewUser([FromBody] RegisterUserCommand command)
        {
            var newUser = await _mediator.Send(command);
            return Ok(newUser);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserViewModel>> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery()
            {
                Id = id
            });
            return Ok(user);
        }

        

        //forgot password / change password
    }
}
