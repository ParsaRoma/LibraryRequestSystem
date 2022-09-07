using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Data.data;
using Infra.Data.IGenericRepository;

namespace Infra.Data.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private IRepository<Books>? bookRepository;
        private IRepository<Users>? usersRepository;
        private IRepository<Shelf>? shelfRepository;
        private IRepository<BookShelf>? bookshelfRepository;

        public IRepository<Books> BookRepository
        {
            get 
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new BaseRepository<Books>(context);
                }
                return bookRepository;
            }
        }
        public IRepository<Users> UsersRepository
        {
            get
            {
                if(this.usersRepository == null)
                {
                    this.usersRepository = new BaseRepository<Users>(context); 
                }
                return usersRepository;
            }
        }
        public IRepository<Shelf> ShelfRepository
        {
            get
            {
                if(this.shelfRepository == null)
                {
                       this.shelfRepository = new BaseRepository<Shelf>(context); 
                }
                return shelfRepository;
            }
        }
        public IRepository<BookShelf> BookShelfRepository
        {
            get
            {
                if(this.bookshelfRepository == null)
                {
                       this.bookshelfRepository = new BaseRepository<BookShelf>(context); 
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