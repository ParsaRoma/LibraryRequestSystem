using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IScoreReports
    {
        public IEnumerable<BookDto> NumberOfEveryUserBook();

        public IEnumerable<PopularDto> PopularReadReadingBook();

        
        public IEnumerable<Shelf> GetOneUserShelfs(int id);

    }
}