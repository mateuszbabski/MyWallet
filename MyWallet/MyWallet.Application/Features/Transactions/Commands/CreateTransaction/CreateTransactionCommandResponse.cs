using FluentValidation.Results;
using MyWallet.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandResponse : BaseResponse
    {
        public int? Id { get; set; }

        public CreateTransactionCommandResponse() : base() { }
        public CreateTransactionCommandResponse(ValidationResult validationResult) : base(validationResult) { }
        public CreateTransactionCommandResponse(string message) : base(message) { }
        public CreateTransactionCommandResponse(string message, bool success) : base(message, success) { }
        public CreateTransactionCommandResponse(int id)
        {
            Id = id;
        }
    }
}
