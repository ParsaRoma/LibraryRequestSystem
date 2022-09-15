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
    public class BookShelvesRepository : GenericRepository <BookShelf>, IBookShelvesRepository
    {
        public BookShelvesRepository(ApplicationDbContext context): base(context) 
        {

        }
    }
}