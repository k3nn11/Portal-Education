using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Services.BookService
{
    public interface IBookService
    {
        Task Create(Book books);

        Task Update(Book book);

        Task Delete(int id);

        Task<List<Book>> GetBookList();

        Task<Book> GetBookById(int? id);
        


    }
}
