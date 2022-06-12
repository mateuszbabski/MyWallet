using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Common
{
    public class AuditableBaseEntity
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        
    }
}
