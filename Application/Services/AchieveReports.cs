using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infra.Data.UnitOfWork;

namespace Application.Services
{
    public class AchieveReports : IAchieveReports
    {
        
        private readonly IUnitOfWork db  ;

        public AchieveReports(IUnitOfWork db)
        {
            this.db = db;
        }

        public  IEnumerable<Books> GetAllBooks()
        {
           var AllBook = db.bookRepository.GetAll();
           return  AllBook;
        }

        public IEnumerable<Users> GetAllUsers()
        {   
            var AllUser = db.userRepository.GetAll();
            return  AllUser;
    
        }

        public IEnumerable<Shelf> GetAllUsersShelf()
        {
            var AllShelves = db.shelfRepository.GetAll();
            return AllShelves;
       
        }
    }
}