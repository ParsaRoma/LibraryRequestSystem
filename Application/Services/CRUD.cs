using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.BaseEntities;
using Infra.Data.UnitOfWork;

namespace Application.Services
{
    public class CRUD<T>
    {   
        private readonly UnitOfWork _db  ;

        public CRUD(UnitOfWork db)
        {
            _db = db;
        }
        public bool AddShelf(IEnumerable<T> entity)
        {
          throw new NotImplementedException();
        }

        public bool AddUser(T entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteShelf(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateShelf(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}