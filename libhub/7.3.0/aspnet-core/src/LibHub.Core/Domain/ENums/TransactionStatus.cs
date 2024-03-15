using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.ENums
{
    public enum TransactionStatus : int
    {
        [Description("Pending")]
        Pending = 1,

        [Description("Approved")]
        Approved = 2,

        [Description("Overdue")]
        Overdue = 3,




    }
}
