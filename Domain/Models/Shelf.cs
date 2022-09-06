using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BaseEntities;

namespace Domain.Models
{
    public class Shelf : BaseEntity
    {
        public string ShelfName { get; set; } = string.Empty;
        public int UserID { get; set; } // DF
        public bool ?BookRead { get; set; }
        public bool ?BookReading { get; set; }
        public bool ?BookRed { get; set; }
        public DateTime ?ReadDate { get; set; }
        public DateTime ?ReadingDate { get; set; }
        public DateTime ?RedDate { get; set; }
        public Users? User { get; set; }
        public ICollection<BookShelf>? BookShelves { get; set; }


    }
}