using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.ENums
{
    public enum BookingStatus: long
    {
        [Description("Available")]
        Available = 1,

        [Description("Busy")]
        Busy = 2,
    }
}
