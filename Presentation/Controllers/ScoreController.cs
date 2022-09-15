using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Domain.Models.DtoModels;
using Domain.Models.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IScoreReports _scoreReports;
        
        public ScoreController(IScoreReports scoreReports)
        {
            _scoreReports = scoreReports;
         
        }
        
        
        [HttpGet]
        [Route("api/NumberOfEveryUserBook")]
        public IEnumerable<NumberOfEveryUserBookDto> NumberOfEveryUserBook()
        {
            return _scoreReports.NumberOfEveryUserBook();
        }



        [HttpGet]
        [Route("api/GetPopularReadReadingBook")]
        public IEnumerable<PopularReadReadingBookDto> GetPopularReadReadingBook()
        {
            return _scoreReports.PopularReadReadingBook();
        }
        
       
        [Authorize(Roles=UserRoles.Admin)]
        [HttpGet]
        [Route("api/GetOneUserShelfs/{id}")]
        public  IEnumerable<Shelf> GetOneUserShelfs(int id)
        {

            var T =  _scoreReports.GetOneUserShelfs(id);
            return T;
         

        }
        

    }
}








