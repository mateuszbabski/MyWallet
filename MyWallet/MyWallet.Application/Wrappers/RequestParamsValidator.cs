//using FluentValidation;
//using MyWallet.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyWallet.Application.Wrappers
//{
//    public class RequestParamsValidator : AbstractValidator<RequestParams>
//    {
//        private string[] allowedSortByColumnNames = {
//            nameof(Transaction.Value),
//            nameof(Transaction.TransactionDate),
//            nameof(Transaction.Type) };

//        public RequestParamsValidator()
//        {
//            RuleFor(r => r.SortBy)
//                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
//                .WithMessage("It's possible to sort only by: Value, Transaction Date and Type");
//        }

//    }
//}
