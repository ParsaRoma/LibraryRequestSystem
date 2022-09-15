using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.DtoModels
{
    public class PopularReadReadingBookDto
    {
        public PopularReadReadingBookDto()
        {}
        public int UserId { get; set; }
        public int BookReadingCount { get; set; }
        public int BookReadCount { get; set; }
    }
}