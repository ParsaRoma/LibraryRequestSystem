using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BaseEntities;

namespace Domain.Models
{
    public class Users : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string UserLastName { get; set; } = string.Empty;
        public ICollection<Shelf>? Shelves { get; set; }

        public object Include(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}