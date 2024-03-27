using Abp.AutoMapper;
using LibHub.Domain.Books;
using LibHub.Domain.ENums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.Dtos
{
    [AutoMap(typeof(Book))]
    public class Get_BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Publisher { get; set; }

        public Guid? ImageId { get; set; }

        public Guid CategoryID { get; set; }

        public BookStatus BookStatus { get; set; }

        public BookCondition BookCondition { get; set; }


    }
}
