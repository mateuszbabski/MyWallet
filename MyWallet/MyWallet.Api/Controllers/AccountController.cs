using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Application.Authentication.AccountDetails;
using MyWallet.Application.Authentication.LoginUser;
using MyWallet.Application.Authentication.RegisterUser;
using MyWallet.Application.Features.Users.Queries.GetUserById;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;

namespace MyWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountServices _accountServices;
        private readonly ICurrentUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IMediator mediator, 
            IAuthenticationService authenticationService, 
            IAccountServices accountServices,
            ICurrentUserService userService,
            IMapper mapper)
        {
            _mediator = mediator;
            _authenticationService = authenticationService;
            _accountServices = accountServices;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest command)
        {
            var user = await _authenticationService.LoginAsync(command);
            return Ok(user);
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUser([FromBody] RegisterUserRequest command)
        {
            var newUser = await _authenticationService.RegisterAsync(command);
            return Ok(newUser);
        }


        [Authorize]
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangePasswordRequest request)
        {
            var updatedUser = await _accountServices.ChangePasswordAsync(request);
            return Ok(updatedUser);
        }



        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<UserViewModel> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery()
            {
                Id = id
            });
            return user;
        }
            

        //forgot password
    }
}


        

