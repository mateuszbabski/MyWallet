using FluentValidation;
using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransactionCommandValidator(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;


        }
    }
}
