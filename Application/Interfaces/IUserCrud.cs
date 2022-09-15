using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserCrud
    {
        public bool DeleteBook(int bookid);
        public bool AddBook();
        public bool EditBook(int bookid);
        public bool GetBook(int bookid);
    }
}
