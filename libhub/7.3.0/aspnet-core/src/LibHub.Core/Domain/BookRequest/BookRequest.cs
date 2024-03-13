using Abp.Domain.Entities.Auditing;
using LibHub.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.BookRequest
{
    public class BookRequest : FullAuditedEntity<Guid>
    {
        public virtual Student StudentID { get; set; }
        public virtual Guid BookID { get; set; }
        public virtual DateTime RequestDate { get; set; }
        public virtual DateTime ReturnDate { get; set; }

       

    }
}
