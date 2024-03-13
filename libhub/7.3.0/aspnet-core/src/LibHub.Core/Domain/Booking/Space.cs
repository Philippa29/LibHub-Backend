using Abp.Domain.Entities.Auditing;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.Booking
{
    public class Space : FullAuditedEntity<Guid>
    {
        public virtual string SpaceName { get; set; }
        public virtual int Capacity { get; set; }

        public virtual string Location { get; set; }
    }
}
