using AutoMapper;
using MyWallet.Application.Features.Budgets.Commands.CreateBudget;
using MyWallet.Application.Features.Budgets.Commands.UpdateBudget;
using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Budget, BudgetViewModel>().ReverseMap();
            CreateMap<Budget, BudgetInListViewModel>().ReverseMap();
            CreateMap<Budget, CreateBudgetCommand>();
            CreateMap<Budget, UpdateBudgetCommand>();
        }
    }
}
