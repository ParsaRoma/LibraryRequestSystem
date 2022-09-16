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

        public IEnumerable<UsersRedBookOnceDto> GetUsersRedBookOnce()
        {
            var UserNumber = _context.users .Include(x => x.Shelves).ThenInclude(x => x.BookShelves).ThenInclude(x => x.Book)
            .GroupBy(x => new {x.Id}).Select
            (
                x => new UsersRedBookOnceDto()
                {
                    UserId = x.Key.Id,
                    Numbers = x.SelectMany(x => x.Shelves).Select(x => x.BookReading == true)
                    .Count()
                }
            );
            return UserNumber.ToList();
        }

        public IEnumerable<PopularReadReadingBookDto> GetPopularReadReadingBook()
        {
            var ReaderUsers = _context.users.Include(x => x.Shelves).ThenInclude(x => x.BookShelves).ThenInclude(x => x.Book).SelectMany(x => x.Shelves)
            .Where(x => x.BookReading == true || x.BookRead == true)
            .GroupBy(x => new {x.Id}).Select
            (
                  x => new PopularReadReadingBookDto()
                  {
                    UserId = x.Key.Id,
                    BookReadingCount = x.Select(x => x.BookReading).Count(),
                    BookReadCount = x.Select(x => x.BookRead).Count()
                  }
            );
            return ReaderUsers.ToList();
        }
        public IEnumerable<MaximumBookVisitsDto> GetMaximumBookVisits()
        {
            var Popular = _context.books.Include(x => x.BookShelves).ThenInclude(x => x.Shelf).ThenInclude(x => x.User)
          
            .GroupBy(x => new {x.Id}).Select
            (
                x => new MaximumBookVisitsDto()
                {
                    BookId = x.Key.Id,
                    NumberOfUsers = x.SelectMany(x => x.BookShelves).Select(x => x.Shelf).Select(x => x.BookRed == true)
                }
            );
            return Popular.ToList();
        }

    }
}


