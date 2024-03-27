using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.Categories
{
    public class Category : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
    
    }
}
