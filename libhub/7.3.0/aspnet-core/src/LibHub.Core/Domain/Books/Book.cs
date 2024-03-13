using Abp.Domain.Entities.Auditing;
using LibHub.Domain.ENums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.Books
{
    public class Book : FullAuditedEntity<Guid>
    {
       public virtual string Title { get; set; }
       public virtual string Author { get; set; }

       public virtual string ISBN { get; set; }

        public virtual string Publisher { get; set; }


        
        public virtual Guid CategoryID { get; set; }

        public virtual string ImageUrl { get; set; }
        public virtual BookStatus BookStatus { get; set; }

        public virtual bool Taken { get; set; }



    }
}
