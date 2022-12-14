using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Domain.Models.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Auth;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]

    public class AchieveController : ControllerBase
    {
        private IAchieveReports _achiveReports;
       
      
        
        public AchieveController(IAchieveReports achieveReports)
        {
            _achiveReports = achieveReports;
      
        }
        
        
        
        [HttpGet]
        [Route("api/AchieveBooks")]
        public IEnumerable<Books> GetAllBooks()
        {
           var res = _achiveReports.GetAllBooks();
            return res;
            
        }
        
        [Authorize(Roles=UserRoles.Admin)]
        [HttpGet]
        [Route("api/AchieveUsers")]
        public IEnumerable<Users> GetAllUsers()
        {
            return _achiveReports.GetAllUsers();
        }
        
        
        [Authorize(Policy ="FirstAccessLevel")]
        [HttpGet]
        [Route("api/AchieveShelves")]
        public IEnumerable<Shelf> GetShelves()
        {
            return _achiveReports.GetAllUsersShelf();
        }
         

    }
}