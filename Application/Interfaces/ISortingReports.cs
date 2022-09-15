using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Models;
using Domain.Models.DtoModels;

namespace Application.Interfaces
{
    public interface ISortingReports
    {
        public IEnumerable<SortingUsersBaseOnRedBookDto> SortingUsersBaseOnRedBook();
        public IEnumerable<MaximumBookVisitsDto> MaximumBookVisits();
    }
}