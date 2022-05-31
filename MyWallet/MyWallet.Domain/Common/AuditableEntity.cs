using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Common
{
    public class AuditableEntity
    {
        
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
