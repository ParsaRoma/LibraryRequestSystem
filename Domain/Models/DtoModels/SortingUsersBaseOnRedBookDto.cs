using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.DtoModels
{
    public class SortingUsersBaseOnRedBookDto
    {
        public SortingUsersBaseOnRedBookDto()
        {
        }

        public int UserId { get; set; }
        public int NumberOfBookRed { get; set; }
    }
}