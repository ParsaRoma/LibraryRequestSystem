using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Infra.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ScoreReports : IScoreReports
    {
        private readonly UnitOfWork db = new UnitOfWork();
        public IEnumerable<BookDto> NumberOfEveryUserBook()
        {
            var Numbers = from book in db.BookRepository.Get() join
            bookshelf in db.BookShelfRepository.Get() on book.Id equals bookshelf.BookID
            join shelf in db.ShelfRepository.Get() on bookshelf.ShelfID equals shelf.Id
            join users in db.UsersRepository.Get() on shelf.UserID equals users.Id 
            group new {users, book} by new {users.Id, users.UserName,users.UserLastName} into groupResult
            select new BookDto()
            {
                 Id = groupResult.Key.Id,
                 UserName = groupResult.Key.UserName,
                 UserLastName = groupResult.Key.UserLastName,
                 BookNumber = groupResult.Count()
            };

            return Numbers;

        }

        public IEnumerable<Shelf> GetOneUserShelfs(int id)
        {
            var AllShelves = db.ShelfRepository.Get(x=> x.UserID == 1);
            return  AllShelves;
        }

        public IEnumerable<RedForOnceDto> BookThatRedForOnce()
        {
            var Numbers = from book in db.BookRepository.Get() join
            bookshelf in db.BookShelfRepository.Get() on book.Id equals bookshelf.BookID
            join shelf in db.ShelfRepository.Get() on bookshelf.ShelfID equals shelf.Id
            join users in db.UsersRepository.Get() on shelf.UserID equals users.Id 
            group new {users,shelf} by new {users.Id, shelf.BookReading, shelf.BookRead} into groupResult 
            select new RedForOnceDto()
            {
                UserId = groupResult.Key.Id,
                Numbers = groupResult.Count(p => p.shelf.BookReading == true)
            };
            return Numbers.Where(b => b.Numbers > 0);
        }

        public IEnumerable<PopularDto> PopularReadReadingBook()
        {
            var Popular = from book in db.BookRepository.Get() join
            bookshelf in db.BookShelfRepository.Get() on book.Id equals bookshelf.BookID
            join shelf in db.ShelfRepository.Get() on bookshelf.ShelfID equals shelf.Id
            join users in db.UsersRepository.Get() on shelf.UserID equals users.Id 
            where shelf.BookRead == true || shelf.BookReading == true
            group new {users,shelf} by new {users.Id, shelf.BookReading, shelf.BookRead} into groupResult 
            select new PopularDto () 
            {
                UserId = groupResult.Key.Id,
                BookReadingCount = groupResult.Count(p => p.shelf.BookReading == true),
                BookReadCount = groupResult.Count(p => p.shelf.BookRead == true)
            };
            return Popular;
        }

       
    }
}
