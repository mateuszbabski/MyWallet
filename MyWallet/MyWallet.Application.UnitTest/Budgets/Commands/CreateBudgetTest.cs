using AutoMapper;
using Moq;
using MyWallet.Application.Interfaces;
using MyWallet.Application.Mapper;
using MyWallet.Application.UnitTest.Mocks;
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
        public CreateBudgetTest()
        {
            _mockBudgetRepository = RepositoryMocks.GetBudgetRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }
    }
}
