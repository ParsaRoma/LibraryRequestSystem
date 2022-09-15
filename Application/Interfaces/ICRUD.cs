using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICRUD<T> where T : class 
    {
        public bool AddShelf(T entity);
        public bool AddUser(T entity);
        public bool DeleteUser(int id);
        public bool DeleteShelf(int id);
        public bool UpdateShelf(int id);
        public bool UpdateUser(int id);
    }
}