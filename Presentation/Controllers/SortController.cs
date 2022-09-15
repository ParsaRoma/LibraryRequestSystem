using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Domain.Models.DtoModels;
using Domain.Models.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    public class SortController : ControllerBase
    {
        private ISortingReports _sortingReports;

        public SortController(ISortingReports sortingReports )
        {
            _sortingReports = sortingReports;
        }
        
        [Authorize(Roles=UserRoles.Admin)]
        [HttpGet]
        [Route("api/SortingUsersBaseOnRedBook")]
        public IEnumerable<SortingUsersBaseOnRedBookDto> SortingUsersBaseOnRedBook()
        {
            return _sortingReports.SortingUsersBaseOnRedBook();
        }
        
        [HttpGet]
        [Route("api/MaximumBookVisits")]
        public IEnumerable<MaximumBookVisitsDto> MaximumBookVisits()
        {
            return _sortingReports.MaximumBookVisits();
        }
        
        
    }
}