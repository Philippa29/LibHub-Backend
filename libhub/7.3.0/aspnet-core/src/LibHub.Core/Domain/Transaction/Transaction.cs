using Abp.Domain.Entities.Auditing;
using LibHub.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibHub.Domain.BookRequest
{
    public class Transaction : FullAuditedEntity<Guid>
    {
        public virtual Student StudentID { get; set; }
        public virtual Guid BookID { get; set; }
        public virtual DateTime RequestDate { get; set; }
        public virtual DateTime ReturnDate { get; set; }

        public virtual Librarian Librarian { get; set; }

        public virtual TransactionStatus Status { get; set; }


       

    }
}
