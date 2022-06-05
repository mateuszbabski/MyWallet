using FluentValidation.Results;
using MyWallet.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandResponse : BaseResponse
    {
        public int? Id { get; set; }

        public UpdateTransactionCommandResponse() : base() { }
        public UpdateTransactionCommandResponse(ValidationResult validationResult) : base(validationResult) { }
        public UpdateTransactionCommandResponse(string message) : base(message) { }
        public UpdateTransactionCommandResponse(string message, bool success) : base(message, success) { }
        public UpdateTransactionCommandResponse(int id)
        {
            Id = id;
        }
    }
}
