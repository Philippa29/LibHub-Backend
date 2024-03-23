using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.ENums
{
    public enum BookStatus : int
    {
        [Description("Available")]
        Available = 1,

        [Description("Unavailable")]
        Unavailable = 2,
    }
}
