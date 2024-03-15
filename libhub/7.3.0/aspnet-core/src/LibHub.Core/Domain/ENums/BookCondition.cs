using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.ENums
{
    public enum BookCondition : int
    {

        [Description("Lost")]
        Lost = 1,

        [Description("Damaged")]
        Damaged = 2,

        [Description("Good")]
        Good = 3,
    }
}
