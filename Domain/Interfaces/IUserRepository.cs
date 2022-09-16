using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.DtoModels;

namespace Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<Users>
    {
         public IEnumerable<SortingUsersBaseOnRedBookDto> GetSortingUsersBaseOnRedBook();
    }
}