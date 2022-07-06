using AutoMapper;
using Moq;
using MyWallet.Application.Features.Budgets.Commands.CreateBudget;
using MyWallet.Application.Interfaces;
using MyWallet.Application.Mapper;
using MyWallet.Application.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.UnitTest.Budgets.Commands
{
    public class CreateBudgetTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IBudgetRepository> _mockBudgetRepository;
        private readonly ICurrentUserService _userService;
        public CreateBudgetTest(ICurrentUserService? userService)
        {
            _mockBudgetRepository = RepositoryMocks.GetBudgetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _userService = userService;
        }

        [Fact]
        public async Task Handle_ValidBudget_AddedToRepo()
        {
            var handler = new CreateBudgetCommandHandler(_mockBudgetRepository.Object, _mapper, _userService);
            var userId = 1;

            var allBudgetsBeforeCount = (await _mockBudgetRepository.Object.GetAllBudgetsAsync(userId)).Count();

            var command = new CreateBudgetCommand()
            {
                Name = "Home Wallet",
                Description = "Tracking expenses",
                UserId = userId
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allBudgets = await _mockBudgetRepository.Object.GetAllBudgetsAsync(userId);

            allBudgets.Count().ShouldBe(allBudgetsBeforeCount + 1);
            response.ShouldBePositive();
            response.ShouldSatisfyAllConditions();
            
        }

        [Fact]
        public async Task Handle_NotValidBudget_NoName_NotAddedToRepo()
        {
            var handler = new CreateBudgetCommandHandler(_mockBudgetRepository.Object, _mapper, _userService);
            var userId = 1;

            var allBudgetsBeforeCount = (await _mockBudgetRepository.Object.GetAllBudgetsAsync(userId)).Count();

            var command = new CreateBudgetCommand()
            {
                Description = "Tracking expenses",
                UserId = userId
            };
                

            var response = await handler.Handle(command, CancellationToken.None);

            var allBudgets = await _mockBudgetRepository.Object.GetAllBudgetsAsync(userId);

            allBudgets.Count().ShouldBe(allBudgetsBeforeCount);
            response.ShouldBeNegative("Name field is empty");
            
        }
            
        [Fact]
        public async Task Handle_NotValidBudget_TooLongName_NotAddedToRepo()
        {
            var handler = new CreateBudgetCommandHandler(_mockBudgetRepository.Object, _mapper, _userService);
            var userId = 1;

            var allBudgetsBeforeCount = (await _mockBudgetRepository.Object.GetAllBudgetsAsync(userId)).Count();

            var command = new CreateBudgetCommand()
            {
                Name = new string('x', 101),
                Description = "Tracking expenses",
                UserId = userId
            };


            var response = await handler.Handle(command, CancellationToken.None);

            var allBudgets = await _mockBudgetRepository.Object.GetAllBudgetsAsync(userId);

            allBudgets.Count().ShouldBe(allBudgetsBeforeCount);
            response.ShouldBeNegative("Name field is too long");
            
        }
    }
}


