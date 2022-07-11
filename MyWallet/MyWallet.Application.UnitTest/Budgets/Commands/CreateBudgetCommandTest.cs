using AutoMapper;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;

using MyWallet.Application.Features.Budgets.Commands.CreateBudget;
using MyWallet.Application.Interfaces;
using MyWallet.Application.Mapper;
using MyWallet.Domain.Entities;
using NSubstitute;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyWallet.Application.UnitTest.Budgets.Commands
{
    public class CreateBudgetCommandTest
    {

        private IMapper _mapper;
        private readonly IBudgetRepository _budgetRepository = Substitute.For<IBudgetRepository>();
        private readonly ICurrentUserService _userService = Substitute.For<ICurrentUserService>();
        private readonly CreateBudgetCommandHandler _sut;



        public CreateBudgetCommandTest()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _sut = new CreateBudgetCommandHandler(_budgetRepository, _mapper, _userService);

        }

        [Fact]
        public async Task CreateBudget_ReturnsTrue_BudgetAdded()
        {
            var userId = 1;
            var budgetDto = new Budget { Name = "Test budget", Description = "Test budget", CreatedById = userId };

            var mappedBudget = _mapper.Map<CreateBudgetCommand>(budgetDto);

            var validator = new CreateBudgetCommandValidator();

            TestValidationResult<CreateBudgetCommand> result = validator.TestValidate(mappedBudget);

            Assert.True(result.IsValid);
            
        }

    }
}
        


