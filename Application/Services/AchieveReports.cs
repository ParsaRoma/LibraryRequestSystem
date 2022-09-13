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
        
        private readonly UnitOfWork db  ;

        public AchieveReports(UnitOfWork db)
        {
            this.db = db;
        }

        public  IEnumerable<Books> GetAllBooks()
        {
           var AllBook = db.BookRepository.List();
           return  AllBook;
        }

        public IEnumerable<Users> GetAllUsers()
        {   
            var AllUser = db.UsersRepository.List();
            return  AllUser;
    
        }

        public IEnumerable<Shelf> GetAllUsersShelf()
        {
            // var AllShelves = db.ShelfRepository.List();
            // return AllShelves;
        throw new NotImplementedException();
        }
    }
}