using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BaseEntities;

namespace Domain.Models
{
    public class Books : BaseEntity
    {
        public string BookName { get; set; } = string.Empty;
        public string BookType { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string PageNumber { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty; 
        public string Published { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public ICollection<BookShelf>? BookShelves { get; set; }
        
    }
}