//using AutoMapper;
//using Moq;
//using MyWallet.Application.Interfaces;
//using MyWallet.Application.Mapper;
//using MockRepository = MyWallet.Application.UnitTest.Mocks.MockRepository;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
//using MyWallet.Domain.Entities;
//using Shouldly;
//using NSubstitute;

//namespace Application.UnitTest.BudgetTest
//{
//    public class GetAllBudgetsQueryHandlerTest
//    {
//        private readonly IMapper _mapper;
//        private readonly IBudgetRepository _budgetRepository = Substitute.For<IBudgetRepository>();
//        private readonly GetAllBudgetQueryHandler _sut;
//        private readonly ICurrentUserService _userService = Substitute.For<ICurrentUserService>();
//        public GetAllBudgetsQueryHandlerTest()
//        {
//            var mapperConfig = new MapperConfiguration(c =>
//            {
//                c.AddProfile<MappingProfile>();
//            });

//            _mapper = mapperConfig.CreateMapper();
//            _sut = new GetAllBudgetQueryHandler(_mapper, _budgetRepository, _userService);

//            //_mockRepo = MockRepository.GetBudgetRepository();
            
//        }

//        [Fact]
//        public async Task GetAllBudgets_ShowBudgets_ValidParameters()
//        {
            
//            //var mockBudgetRepository = new Mock<IBudgetRepository>();
//            var budgetList = GetBudgets();
//            int userId = 1;
//            var res = _sut.Handle()
//            //var result = mockBudgetRepository.Setup(r => r.GetAllBudgetsAsync(It.IsAny<int>())).ReturnsAsync((int userId) =>
//            //{
//            //    userId = 1;
//            //    var budget = budgetList.Where(b => b.CreatedById == userId).ToList();
//            //    return budget;
//            //});


//            result.ShouldNotBeNull();
//            result.ShouldBeOfType<List<Budget>>();
            
            
            
//        }

            
            
            

//        private static List<Budget> GetBudgets()
//        {

//            Budget b1 = new Budget()
//            {
//                Id = 1,
//                CreatedById = 1,
//                Name = "Budget1",
//                Description = "Test1"
//            };

//            Budget b2 = new Budget()
//            {
//                Id = 2,
//                CreatedById = 1,
//                Name = "Budget2",
//                Description = "Test2"
//            };

//            List<Budget> b = new List<Budget>();
//            b.Add(b1);
//            b.Add(b2);

//            return b;
            
//        }


            
            
//    }
//}
