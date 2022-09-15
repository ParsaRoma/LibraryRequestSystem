using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Infra.Data.DAL;

namespace Application.Services
{
    public class AdminCrud : IAdminCrud
    {
        private readonly UnitOfWork _db;
        public AdminCrud(UnitOfWork db)
        {
            _db = db;
        }
       
        public bool CreatUser()
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}