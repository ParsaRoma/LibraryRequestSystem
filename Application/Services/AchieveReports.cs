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

        public  IEnumerable<Books> GetAllBooks()
        {
        //    var AllBook = db.BookRepository.GetAll();
        //    return await AllBook;
        throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAllUsers()
        {   
            // var AllUser = db.UsersRepository.GetAll();
            // return awa AllUser;
        throw new NotImplementedException();
        }

        public IEnumerable<Shelf> GetAllUsersShelf()
        {
            // var AllShelves = db.ShelfRepository.List();
            // return AllShelves;
        throw new NotImplementedException();
        }
    }
}