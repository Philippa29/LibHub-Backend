using Abp.Domain.Entities.Auditing;
using LibHub.Domain.ENums;
using LibHub.Domain.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.Booking
{
    public class Booking : FullAuditedEntity<Guid>
    {

        public virtual Space SpaceID { get; set; }
        public virtual DateTime BookingDate { get; set; }

        public virtual DateTime StartTime { get; set; }

        public virtual DateTime EndTime { get; set; }

        public virtual Person BookedBy { get; set; }

        public virtual BookingStatus BookingStatus { get; set; }



    }

}

