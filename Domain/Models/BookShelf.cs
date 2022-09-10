using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BaseEntities;

namespace Domain.Models
{
    public class BookShelf : BaseEntity
    {
        public int ?ShelfID { get; set; }
        public int ?BookID { get; set; }
        public Books? Book { get; set; }
        public Shelf? Shelf { get; set; }
        
        
    }
}