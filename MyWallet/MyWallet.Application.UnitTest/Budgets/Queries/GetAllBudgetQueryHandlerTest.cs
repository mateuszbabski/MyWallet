using AutoMapper;

using MyWallet.Application.Exceptions;
using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Application.Interfaces;
using MyWallet.Application.Mapper;

using MyWallet.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyWallet.Application.UnitTest.Budgets.Queries
{
    public class GetBudgetsListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        
        
        public GetBudgetsListQueryHandlerTest()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            
        }

    }
}


            

        
            
            
