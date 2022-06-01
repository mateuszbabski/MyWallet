using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Transactions.Queries.GetAllTransactions
{
    public class TransactionInListViewModel
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public decimal Value { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public virtual Budget Budget { get; set; }
    }
}
