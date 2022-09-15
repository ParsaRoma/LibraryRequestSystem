using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infra.Data.data;
using Infra.Data.TypeRepository;

namespace Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private BookRepository _bookRepository;
        private UserRepository _userRepository;
        private BookShelvesRepository _bookShelvesRepository;
        private ShelfRepository _shelfRepository;



        public UnitOfWork(
        
        ApplicationDbContext context
        )

        {
            _context = context;
            _bookRepository = new BookRepository(_context);
            _userRepository = new UserRepository(_context);
            _shelfRepository = new ShelfRepository(_context);
            _bookShelvesRepository = new BookShelvesRepository(_context);
        }


        public IBookRepository bookRepository  => _bookRepository; // When you dont use set in properties it means private set

        public IUserRepository userRepository => _userRepository;

        public IBookShelvesRepository bookShelvesRepository => _bookShelvesRepository;
        
        public IShelfRepository shelfRepository => _shelfRepository;

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}