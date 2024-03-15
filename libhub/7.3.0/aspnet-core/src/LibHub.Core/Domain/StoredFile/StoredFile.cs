using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Domain.StoredFiles
{
    public class StoredFile: FullAuditedEntity<Guid>
    {
    
        public virtual string FileName { get; set; }

        public virtual string FileType { get; set; }

        public virtual string Folder { get; set; }
    }
}
