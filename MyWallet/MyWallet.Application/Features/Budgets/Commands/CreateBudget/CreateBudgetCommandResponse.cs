using FluentValidation.Results;
using MyWallet.Application.Wrappers;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Commands.CreateBudget
{
    public class CreateBudgetCommandResponse : BaseResponse
    {
        public int? Id { get; set; }

        public CreateBudgetCommandResponse() : base() { }
        public CreateBudgetCommandResponse(ValidationResult validationResult) : base(validationResult) { }
        public CreateBudgetCommandResponse(string message) : base(message) { }
        public CreateBudgetCommandResponse(string message, bool success) : base(message, success) { }
        public CreateBudgetCommandResponse(int id)
        {
            Id = id;
        }
    }
}
