using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IAchieveReports
    {
        public IEnumerable<Books> GetAllBooks();
        public IEnumerable<Users> GetAllUsers();
        public IEnumerable<Shelf> GetAllUsersShelf(); 
    }
}