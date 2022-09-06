using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ISortingReports
    {
        public IEnumerable<UsersSortDto> SortingUsersBaseOnRedBook();
        public IEnumerable<BookSortDto> MaximumBookVisits();
    }
}