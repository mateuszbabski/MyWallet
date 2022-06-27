using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyWallet.Application.Authentication.AccountDetails;
using MyWallet.Application.Interfaces;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Identity.Services
{


    public class AccountServices : IAccountServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        

        public AccountServices(IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            IMapper mapper,
            ICurrentUserService userService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _userService = userService;
        }
        //change password

        public async Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordRequest request)
        {
            var currentUser = _userRepository.GetUserByIdAsync(_userService.GetUserId);
            var user = _mapper.Map<User>(currentUser.Result);

            if (request.OldPassword != user.Password || request.NewPassword != request.ConfirmNewPassword)
                return new ChangePasswordResponse
                {
                    IsSuccess = false,
                    Errors = "OldPassword is incorrect or Confirmed and New Password are not equal"
                };

            
            user.Password = request.NewPassword;
            user.PasswordHash = _passwordHasher.HashPassword(user, request.NewPassword);


            var changedPasswordUser = _mapper.Map<User>(request);

            await _userRepository.UpdateUserPasswordAsync(changedPasswordUser);
            
            return await Task.FromResult(new ChangePasswordResponse
            {
                IsSuccess = true,
                Password = request.NewPassword
            });

        }



            

        //reset password
        //public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        //{
        // user by email
        // find email
        // send email with password
        //}

    }
}


