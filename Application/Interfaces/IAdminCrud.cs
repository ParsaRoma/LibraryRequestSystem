using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Data.DAL;

namespace Application.Interfaces
{
    public interface IAdminCrud
    {
        public bool DeleteUser(int id);
        public bool CreatUser();
        public bool EditUser(int id);
        public bool GetUser(int id);
    }
}