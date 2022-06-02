using AutoMapper;
using MyWallet.Application.Features.Budgets.Commands.CreateBudget;
using MyWallet.Application.Features.Budgets.Commands.UpdateBudget;
using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Application.Features.Transactions.Commands.CreateTransaction;
using MyWallet.Application.Features.Transactions.Commands.UpdateTransaction;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionById;
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
            CreateMap<UpdateBudgetCommand, Budget>();

            CreateMap<Transaction, TransactionViewModel>();
            CreateMap<Transaction, TransactionInListViewModel>();
            CreateMap<CreateTransactionCommand, Transaction>();
            CreateMap<UpdateTransactionCommand, Transaction>();
        }
    }
}
