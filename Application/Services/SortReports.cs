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
        private readonly UnitOfWork db = new UnitOfWork();

        public IEnumerable<BookSortDto> MaximumBookVisits()
        {
            var book = db.BookRepository.Get().join.in
            var BookSort = from book in db.BookRepository.Get() join
            bookshelf in db.BookShelfRepository.Get() on book.Id equals bookshelf.BookID
            join shelf in db.ShelfRepository.Get() on bookshelf.ShelfID equals shelf.Id
            join users in db.UsersRepository.Get() on shelf.UserID equals users.Id
            where shelf.BookRed == true
            // group new{book,users,shelf} by new {book.Id, userId = users.Id, shelf.BookRed} into groupResult
            group book by book.Id into groupResult
            select new BookSortDto()
            {
                BookId = groupResult.Key,
                NumberOfUsers = groupResult.Count()
            };
            return BookSort.OrderByDescending(c => c.NumberOfUsers);

        }

        public IEnumerable<UsersSortDto> SortingUsersBaseOnRedBook()
        {
            var UserSort = from book in db.BookRepository.Get() join
            bookshelf in db.BookShelfRepository.Get() on book.Id equals bookshelf.BookID
            join shelf in db.ShelfRepository.Get() on bookshelf.ShelfID equals shelf.Id
            join users in db.UsersRepository.Get() on shelf.UserID equals users.Id
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