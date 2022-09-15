using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Infra.Data.data;
using Infra.Data.GenericRepository;

namespace Infra.Data.TypeRepository
{


 public class UserRepository : GenericRepository <Users>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context): base(context) 
        {

        }
    }
}