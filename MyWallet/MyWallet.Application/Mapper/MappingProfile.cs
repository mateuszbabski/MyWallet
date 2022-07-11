using AutoMapper;
using MyWallet.Application.Authentication.AccountDetails;
using MyWallet.Application.Authentication.RegisterUser;
using MyWallet.Application.Features.Budgets.Commands.CreateBudget;
using MyWallet.Application.Features.Budgets.Commands.UpdateBudget;
using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Application.Features.Transactions.Commands.CreateTransaction;
using MyWallet.Application.Features.Transactions.Commands.UpdateTransaction;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionById;
using MyWallet.Application.Features.Users.Queries.GetUserById;
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
            CreateMap<Budget, CreateBudgetCommand>().ReverseMap();
            CreateMap<Budget, UpdateBudgetCommand>().ReverseMap();


            CreateMap<Transaction, TransactionViewModel>().ReverseMap();
            CreateMap<Transaction, TransactionInListViewModel>().ReverseMap();
            CreateMap<CreateTransactionCommand, Transaction>().ReverseMap();
            CreateMap<UpdateTransactionCommand, Transaction>().ReverseMap();

            CreateMap<RegisterUserRequest, User>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();

            CreateMap<ChangePasswordRequest, User>()
                .ForMember(x => x.Password, c => c.MapFrom(w => w.NewPassword));

            
        }
    }
}
