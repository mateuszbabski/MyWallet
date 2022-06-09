using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyWallet.Application.Authentication.Responses;
using MyWallet.Application.Authentication.Settings;
using MyWallet.Application.Exceptions;
using MyWallet.Application.Features.Users.Commands.LoginUser;
using MyWallet.Application.Features.Users.Commands.RegisterUser;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Authentication.Services
{
    public class AuthenticationServices : IAuthentication
    {
        private readonly IUserRepository _userRepository;
        private readonly JWTSettings _jwtSettings;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationServices(IUserRepository userRepository, JWTSettings jwtSettings, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<AuthenticationResponse> LoginAsync(LoginUserCommand request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if(user == null)
            {
                return new AuthenticationResponse { Errors = new[] { "Email or password incorrect" } };
            }

            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if(verifyPassword == PasswordVerificationResult.Failed)
            {
                return new AuthenticationResponse { Errors = new[] { "Email or password incorrect" } };
            }

            return await GenerateAuthenticationResponseForUserAsync(user);
        }

        public async Task<AuthenticationResponse> RegisterAsync(RegisterUserCommand request)
        {
            var isEmailInUse = await _userRepository.GetUserByEmailAsync(request.Email);
            if (isEmailInUse != null)
            {
                throw new BadRequestException("Email is already in use");
            }
            var newUser = _mapper.Map<User>(request);
            await _userRepository.RegisterNewUserAsync(newUser);

            return await GenerateAuthenticationResponseForUserAsync(newUser);
        }

        private Task<AuthenticationResponse> GenerateAuthenticationResponseForUserAsync(User user)
        {
            
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName}"),
                new Claim(ClaimTypes.Email, $"{user.Email}")
            };

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = _jwtSettings.Audience,
                Expires = expires,
                SigningCredentials = cred
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new AuthenticationResponse
            {
                IsSuccess = true,
                Token = jwtHandler.WriteToken(token)
            });
        }
    }
}
