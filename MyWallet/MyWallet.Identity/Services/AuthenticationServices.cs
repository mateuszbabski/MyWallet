using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Identity.Services
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
        public async Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return new AuthenticationResponse { Errors = new[] { "Email or password incorrect" } };
            }

            var verifyPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (verifyPassword == PasswordVerificationResult.Failed)
            {
                return new AuthenticationResponse { Errors = new[] { "Email or password incorrect" } };
            }

            return await GenerateAuthenticationResponseForUserAsync(user);
        }

        public async Task<AuthenticationResponse> RegisterAsync(RegisterAccountRequest request)
        {
            var isEmailInUse = await _userRepository.GetUserByEmailAsync(request.Email);
            if (isEmailInUse != null)
            {
                return new AuthenticationResponse { Errors = new[] { "Email is already in use" } };
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

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(claims),
            //    Issuer = _jwtSettings.Issuer,
            //    Audience = _jwtSettings.Audience,
            //    Expires = expires,
            //    SigningCredentials = cred
            //};

            var tokenDescriptor = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: expires,
                signingCredentials: cred);

            //var token = jwtHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new AuthenticationResponse
            {
                IsSuccess = true,
                Token = jwtHandler.WriteToken(tokenDescriptor)
            });
        }
    }
}
