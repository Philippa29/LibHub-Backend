using Abp.Domain.Entities.Auditing;
using LibHub.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.Users
{
    public class Person : FullAuditedEntity<Guid>
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Email { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual User User { get; set; }


    }
}
