using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Models;
using Domain.Models.DtoModels;

namespace Application.Interfaces
{
    public interface IScoreReports
    {
        public IEnumerable<NumberOfEveryUserBookDto> NumberOfEveryUserBook();

        public IEnumerable<PopularReadReadingBookDto> PopularReadReadingBook();

        
        public IEnumerable<Shelf> GetOneUserShelfs(int id);

    }
}