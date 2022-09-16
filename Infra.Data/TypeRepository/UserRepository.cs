using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.DtoModels;
using Infra.Data.data;
using Infra.Data.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.TypeRepository
{


 public class UserRepository : GenericRepository <Users>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context): base(context) 
        {

        }

        public IEnumerable<SortingUsersBaseOnRedBookDto> GetSortingUsersBaseOnRedBook()
        {
            var UserSort = _context.users.Include(x => x.Shelves).ThenInclude(x => x.BookShelves).ThenInclude(x => x.Book)
            .GroupBy(x => new {x.Id})
            .Select
            (
                x => new SortingUsersBaseOnRedBookDto()
                {
                    UserId = x.Key.Id,
                    NumberOfBookRed = x.SelectMany(x => x.Shelves).Select(x => x.BookRead == true).Count()
                }
            );
        return UserSort.ToList();
        }
    }
}