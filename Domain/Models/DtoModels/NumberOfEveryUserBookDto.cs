using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.DtoModels

{
    public class NumberOfEveryUserBookDto
    {
        
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string UserLastName { get; set; }
    public int BookNumber { get; set; }
    }
}