using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Infra.Data.DAL;

namespace Application.Services
{
    public class SortReports : ISortingReports
    {
        private readonly UnitOfWork db;

        public SortReports(UnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<BookSortDto> MaximumBookVisits()
        {
            
            var BookSort = from book in db.BookRepository.List() join
            bookshelf in db.BookShelfRepository.List() on book.Id equals bookshelf.BookID
            join shelf in db.ShelfRepository.List() on bookshelf.ShelfID equals shelf.Id
            join users in db.UsersRepository.List() on shelf.UserID equals users.Id
            where shelf.BookRed == true
            // group new{book,users,shelf} by new {book.Id, userId = users.Id, shelf.BookRed} into groupResult
            group book by book.Id into groupResult
            select new BookSortDto()
            {
                BookId = groupResult.Key,
                NumberOfUsers = groupResult.Count()
            };
            return BookSort.OrderByDescending(c => c.NumberOfUsers);
        throw new NotImplementedException();
        }

        public IEnumerable<UsersSortDto> SortingUsersBaseOnRedBook()
        {
            var UserSort = from book in db.BookRepository.List() join
            bookshelf in db.BookShelfRepository.List() on book.Id equals bookshelf.BookID
            join shelf in db.ShelfRepository.List() on bookshelf.ShelfID equals shelf.Id
            join users in db.UsersRepository.List() on shelf.UserID equals users.Id
            group new {users, shelf} by new {users.Id, shelf.BookRed} into groupResult
            select new UsersSortDto ()
            {
                UserId = groupResult.Key.Id,
                NumberOfBookRed = groupResult.OrderByDescending(s => s.shelf.BookRed)
                .Count(s => s.shelf.BookRed == true)
            };
            return UserSort.OrderByDescending(s => s.NumberOfBookRed).ThenByDescending(s => s.UserId);
   
        }
    }
}