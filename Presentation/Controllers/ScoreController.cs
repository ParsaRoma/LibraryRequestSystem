using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{

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
        public IEnumerable<BookDto> NumberOfEveryUserBook()
        {
            return _scoreReports.NumberOfEveryUserBook();
        } 
        [HttpGet]
        [Route("api/GetPopularReadReadingBook")]
        public IEnumerable<PopularDto> GetPopularReadReadingBook()
        {
            return _scoreReports.PopularReadReadingBook();
        }
        [HttpGet]
        [Route("api/BookThatRedForOnce")]
        
        [HttpGet]
        [Route("api/GetOneUserShelfs/{id}")]

        public  IEnumerable<Shelf> GetOneUserShelfs(int id)
        {

            // try
            // {
                var T =  _scoreReports.GetOneUserShelfs(id);
                return T;
            // }catch(SystemException ex)
            // {
            //     // return StatusCode(StatusCodes.Status500InternalServerError,
            //         // "Error retrieving data from the database");
            // }

        }
        

    }
}








