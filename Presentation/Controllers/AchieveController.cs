using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
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
            return _achiveReports.GetAllBooks();
        }
        [HttpGet]
        [Route("api/AchieveUsers")]
        public IEnumerable<Users> GetAllUsers()
        {
            return _achiveReports.GetAllUsers();
        }
        [HttpGet]
        [Route("api/AchieveShelves")]
        public IEnumerable<Shelf> GetShelves()
        {
            return _achiveReports.GetAllUsersShelf();
        }
         

    }
}