using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.DtoModels
{
    public class MaximumBookVisitsDto
    {
        public MaximumBookVisitsDto()
        {
        }

        public object BookId { get; set; }
        public object NumberOfUsers { get; set; }
    }
}
