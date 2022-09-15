using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork :  IDisposable{

        IBookRepository bookRepository {
            
            get;
        }

        IUserRepository userRepository{

            get;
        }

        IBookShelvesRepository bookShelvesRepository{

            get;
        }

        IShelfRepository shelfRepository{

            get;
        }

        int Save();
        
    }
}