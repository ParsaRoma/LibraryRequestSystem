using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Domain.Models.DtoModels;
using Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ScoreReports : IScoreReports
    {
        private readonly UnitOfWork db ;

        public ScoreReports(UnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<NumberOfEveryUserBookDto> NumberOfEveryUserBook()
        {
        var Numbers = db.bookRepository.GetScoreReport().Select(x => new NumberOfEveryUserBookDto{

            UserId = x.UserId,
            UserName = x.UserName,
            UserLastName = x.UserLastName,
            BookNumber = x.BookNumber

        });
        
        return Numbers.OrderByDescending(query => query.BookNumber);
        }

        public IEnumerable<Shelf> GetOneUserShelfs(int id)
        {
            var AllShelves = db.shelfRepository.GetAll().Where(x=> x.UserID == 1);
            return  AllShelves;
        
        }

        public IEnumerable<UsersRedBookOnceDto> UsersRedBookOnce() // Users who are reading at least one book
        {
          
            var Numbers = from book in db.bookRepository.GetAll() join
            bookshelf in db.bookShelvesRepository.GetAll() on book.Id equals bookshelf.BookID
            join shelf in db.shelfRepository.GetAll() on bookshelf.ShelfID equals shelf.Id
            join users in db.userRepository.GetAll() on shelf.UserID equals users.Id 
            group new {users,shelf} by new {users.Id, shelf.BookReading, shelf.BookRead} into groupResult 
            select new UsersRedBookOnceDto()
            {
                UserId = groupResult.Key.Id,
                Numbers = groupResult.Count(p => p.shelf.BookReading == true)
            };
            return Numbers.Where(b => b.Numbers > 0);
 
        }

        public IEnumerable<PopularReadReadingBookDto> PopularReadReadingBook()
        {
            var Popular = from book in db.bookRepository.GetAll() join
            bookshelf in db.bookShelvesRepository.GetAll() on book.Id equals bookshelf.BookID
            join shelf in db.shelfRepository.GetAll() on bookshelf.ShelfID equals shelf.Id
            join users in db.userRepository.GetAll() on shelf.UserID equals users.Id 
            where shelf.BookRead == true || shelf.BookReading == true
            group new {users,shelf} by new {users.Id, shelf.BookReading, shelf.BookRead} into groupResult 
            select new PopularReadReadingBookDto () 
            {
                UserId = groupResult.Key.Id,
                BookReadingCount = groupResult.Count(p => p.shelf.BookReading == true),
                BookReadCount = groupResult.Count(p => p.shelf.BookRead == true)
            };
            return Popular;
        }

    
    }

      
    }  

