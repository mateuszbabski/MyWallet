using FluentValidation.Results;
using MyWallet.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Commands.UpdateBudget
{
    public class UpdateBudgetCommandResponse : BaseResponse
    {
        public int? Id { get; set; }

        public UpdateBudgetCommandResponse() : base() { }
        public UpdateBudgetCommandResponse(ValidationResult validationResult) : base(validationResult) { }
        public UpdateBudgetCommandResponse(string message) : base(message) { }
        public UpdateBudgetCommandResponse(string message, bool success) : base(message, success) { }
        public UpdateBudgetCommandResponse(int id)
        {
            Id = id;
        }
    }
}
