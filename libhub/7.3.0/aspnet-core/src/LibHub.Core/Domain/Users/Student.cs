using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.Users
{
    public class Student : Person
    {
        public virtual string StudentID { get; set; }
    }
}
