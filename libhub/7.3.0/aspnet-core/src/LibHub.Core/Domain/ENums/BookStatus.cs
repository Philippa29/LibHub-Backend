using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.ENums
{
    public enum BookStatus : long
    {
        [Description("Available")]
        Available = 1,

        [Description("Taken")]
        Taken = 2,

        [Description("Lost")]
        Lost = 3,

        [Description("Damaged")]
        Damaged = 4,
    }
}
