using Data.Generic_interface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        public BookService(IRepository<Book> bookRepository) 
        {
            _bookRepository = bookRepository;
        }
        public async Task Create(Book book)
        {
            if (book != null)
            {
                await _bookRepository.Create(book);
            }
        }

        public async Task Delete(int id)
        {
             await _bookRepository.Delete(id);
        }

        public async Task<Book> GetBookById(int? id)
        {
            return await _bookRepository.GetByID(id);
        }

        public async Task<List<Book>> GetBookList()
        {
            return await _bookRepository.GetAll();
        }

        public async Task Update(Book book)
        {
            await _bookRepository.Update(book);
        }
    }
}
