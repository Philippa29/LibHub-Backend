using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.Category
{
    public class Category : FullAuditedEntity<Guid>
    {

        //type 
        public virtual string Type { get; set; }
        public virtual Category SubCategory { get; set; }
    }
}
