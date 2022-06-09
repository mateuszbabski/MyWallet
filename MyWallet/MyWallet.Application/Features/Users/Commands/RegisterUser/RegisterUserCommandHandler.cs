using AutoMapper;
using MediatR;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<User>(request);
            await _userRepository.RegisterNewUserAsync(newUser);

            return Unit.Value;
        }
    }
}
