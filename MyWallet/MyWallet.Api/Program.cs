using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyWallet.Application;
using MyWallet.Application.Features.Budgets.Commands.CreateBudget;
using MyWallet.Application.Features.Transactions.Commands.CreateTransaction;
using MyWallet.Application.Interfaces;
using MyWallet.Persistence;
using MyWallet.Persistence.Context;
using MyWallet.Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));
builder.Services.AddApplicationCore();
builder.Services.AddInfrastructure(builder.Configuration);



builder.Services.AddControllers();



//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddScoped<IValidator<CreateBudgetCommand>, CreateBudgetCommandValidator>();
//builder.Services.AddScoped<IValidator<CreateTransactionCommand>, CreateTransactionCommandValidator>();
//builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
//builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
