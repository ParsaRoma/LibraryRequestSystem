using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Data.data;

namespace Infra.Data.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private GenericRepository<Books>? bookRepository;
        private GenericRepository<Users>? usersRepository;
        private GenericRepository<Shelf>? shelfRepository;
        private GenericRepository<BookShelf>? bookshelfRepository;

        public GenericRepository<Books> BookRepository
        {
            get 
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Books>(context);
                }
                return bookRepository;
            }
        }
        public GenericRepository<Users> UsersRepository
        {
            get
            {
                if(this.usersRepository == null)
                {
                       this.usersRepository = new GenericRepository<Users>(context); 
                }
                return usersRepository;
            }
        }
        public GenericRepository<Shelf> ShelfRepository
        {
            get
            {
                if(this.shelfRepository == null)
                {
                       this.shelfRepository = new GenericRepository<Shelf>(context); 
                }
                return shelfRepository;
            }
        }
        public GenericRepository<BookShelf> BookShelfRepository
        {
            get
            {
                if(this.bookshelfRepository == null)
                {
                       this.bookshelfRepository = new GenericRepository<BookShelf>(context); 
                }
                return bookshelfRepository;
            }
        }

        

        public void SaveChange()
        {
            context.SaveChanges();
        }

        private bool dispose = false;
        public virtual void Dispose(bool disposing)
        {
            if(!this.dispose)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.dispose = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
           
    }
}