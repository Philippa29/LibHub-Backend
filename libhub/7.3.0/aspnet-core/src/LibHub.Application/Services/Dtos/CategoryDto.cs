using Abp.AutoMapper;
using LibHub.Domain.Categories;
using LibHub.Domain.ENums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LibHub.Services.Dtos
{
    [AutoMap(typeof(Category))]
    public class CategoryDto
    {

        public virtual string Name { get; set; }


    }
}
