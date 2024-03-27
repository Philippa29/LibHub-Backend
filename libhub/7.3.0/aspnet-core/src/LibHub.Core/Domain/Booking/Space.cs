using Abp.Domain.Entities.Auditing;
using LibHub.Domain.ENums;
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
        public virtual string Name { get; set; }
        public virtual int Capacity { get; set; }

        public virtual string Location { get; set; }

        public virtual SpaceStatus Status { get; set; }
    }
}
