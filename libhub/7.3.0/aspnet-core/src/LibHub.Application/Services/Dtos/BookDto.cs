using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using LibHub.Domain.Books;
using LibHub.Domain.ENums;
using LibHub.Domain.StoredFiles;

namespace LibHub.Services.Dtos
{
    [AutoMap(typeof(Book))]
    public class BookDto
    {
        public string Title { get; set; }
        public  string Author { get; set; }

        public string ISBN { get; set; }

        public string Publisher { get; set; }

        public Guid? ImageId { get; set; }

        public Guid CategoryID { get; set; }

        
        public BookStatus BookStatus { get; set; }

        public BookCondition BookCondition { get; set; }




    }
}
