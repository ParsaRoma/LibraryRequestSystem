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
    public class BookRepository : GenericRepository<Books>, IBookRepository
    {

        public BookRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<NumberOfEveryUserBookDto> GetScoreReport()
        {
            var number = _context.users
            .Include(x => x.Shelves).ThenInclude(x => x.BookShelves).ThenInclude(x => x.Book)
            .GroupBy(x =>  new {x.Id,x.UserName, x.UserLastName} ).Select
            (
                x => new NumberOfEveryUserBookDto()
                {
                    UserId = x.Key.Id,
                    UserName = x.Key.UserName,
                    UserLastName = x.Key.UserLastName,
                    BookNumber = x.SelectMany(c => c.Shelves).SelectMany(c => c.BookShelves).Select(c => c.BookID).Count()
                    
                }
            
            );
        return number.ToList();

        }


    }
}


