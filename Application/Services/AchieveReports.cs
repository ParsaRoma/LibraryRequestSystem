using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Infra.Data.DAL;

namespace Application.Services
{
    public class AchieveReports : IAchieveReports
    {
        
        private readonly UnitOfWork db = new UnitOfWork();

        public IEnumerable<Books> GetAllBooks()
        {
           var AllBook = db.BookRepository.Get().ToList<Books>();
           return AllBook;
        }

        public IEnumerable<Users> GetAllUsers()
        {   
            var AllUser = db.UsersRepository.Get().ToList<Users>();
            return AllUser;
        
        }

        public IEnumerable<Shelf> GetAllUsersShelf()
        {
            var AllShelves = db.ShelfRepository.Get().ToList<Shelf>();
            return AllShelves;
        }
    }
}