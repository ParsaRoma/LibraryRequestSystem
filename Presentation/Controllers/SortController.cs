using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    
    [ApiController]
    public class SortController : ControllerBase
    {
        private ISortingReports _sortingReports;

        public SortController(ISortingReports sortingReports )
        {
            _sortingReports = sortingReports;
        }
        
        [HttpGet]
        [Route("api/SortingUsersBaseOnRedBook")]
        public IEnumerable<UsersSortDto> SortingUsersBaseOnRedBook()
        {
            return _sortingReports.SortingUsersBaseOnRedBook();
        }
        
        [HttpGet]
        [Route("api/MaximumBookVisits")]
        public IEnumerable<BookSortDto> MaximumBookVisits()
        {
            return _sortingReports.MaximumBookVisits();
        }
        
        
    }
}