using MyWallet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Entities
{
    public class Budget 
    {
        public int Id { get; set; }
        //public int UserID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Transaction> Transactions { get; set; }
        //public virtual User User { get; set; }
    }
}
        
