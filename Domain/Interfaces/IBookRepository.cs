using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.DtoModels;

namespace Domain.Interfaces
{
    public interface IBookRepository : IGenericRepository<Books>
    {
        IEnumerable<NumberOfEveryUserBookDto> GetScoreReport();
        public IEnumerable<UsersRedBookOnceDto> GetUsersRedBookOnce();
        public IEnumerable<PopularReadReadingBookDto> GetPopularReadReadingBook();
        public IEnumerable<MaximumBookVisitsDto> GetMaximumBookVisits();
    }
}

