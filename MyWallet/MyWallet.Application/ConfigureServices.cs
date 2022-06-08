using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyWallet.Application.Behaviours;
using MyWallet.Application.Features.Budgets.Commands.CreateBudget;
using MyWallet.Application.Features.Budgets.Commands.UpdateBudget;
using MyWallet.Application.Features.Transactions.Commands.CreateTransaction;
using MyWallet.Application.Features.Transactions.Commands.UpdateTransaction;
using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddScoped<IValidator<CreateBudgetCommand>, CreateBudgetCommandValidator>();
            //services.AddScoped<IValidator<UpdateBudgetCommand>, UpdateBudgetCommandValidator>();
            //services.AddScoped<IValidator<CreateTransactionCommand>, CreateTransactionCommandValidator>();
            //services.AddScoped<IValidator<UpdateTransactionCommand>, UpdateTransactionCommandValidator>();

            return services;
        }
    }
}


