using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.DtoModels;
using Infra.Data.UnitOfWork;

namespace Application.Services
{
    public class SortReports : ISortingReports
    {
        private readonly IUnitOfWork db;

        public SortReports(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<MaximumBookVisitsDto> MaximumBookVisits()
        {
            var BookSort = db.bookRepository.GetMaximumBookVisits().Select(x => new MaximumBookVisitsDto
            {
                BookId = x.BookId,
                NumberOfUsers = x.NumberOfUsers
            });
            // var BookSort = from book in db.bookRepository.GetAll() join
            // bookshelf in db.bookShelvesRepository.GetAll() on book.Id equals bookshelf.BookID
            // join shelf in db.shelfRepository.GetAll() on bookshelf.ShelfID equals shelf.Id
            // join users in db.userRepository.GetAll() on shelf.UserID equals users.Id
            // where shelf.BookRed == true
            // group book by book.Id into groupResult
            // select new MaximumBookVisitsDto()
            // {
            //     BookId = groupResult.Key,
            //     NumberOfUsers = groupResult.Count()
            // };
            return BookSort.OrderByDescending(c => c.NumberOfUsers);
        }

        public IEnumerable<SortingUsersBaseOnRedBookDto> SortingUsersBaseOnRedBook()
        {
            var UserSort = db.userRepository.GetSortingUsersBaseOnRedBook().Select(x => new SortingUsersBaseOnRedBookDto
            {
                UserId = x.UserId,
                NumberOfBookRed = x.NumberOfBookRed
            });
            // var UserSort = from book in db.bookRepository.GetAll() join
            // bookshelf in db.bookShelvesRepository.GetAll() on book.Id equals bookshelf.BookID
            // join shelf in db.shelfRepository.GetAll() on bookshelf.ShelfID equals shelf.Id
            // join users in db.userRepository.GetAll() on shelf.UserID equals users.Id
            // group new {users, shelf} by new {users.Id, shelf.BookRed} into groupResult
            // select new SortingUsersBaseOnRedBookDto ()
            // {
            //     UserId = groupResult.Key.Id,
            //     NumberOfBookRed = groupResult.OrderByDescending(s => s.shelf.BookRed)
            //     .Count(s => s.shelf.BookRed == true)
            // };
            return UserSort.OrderByDescending(s => s.NumberOfBookRed).ThenByDescending(s => s.UserId);
   
        }
    }
} 