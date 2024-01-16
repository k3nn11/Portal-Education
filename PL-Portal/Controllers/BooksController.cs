using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.BookService;
using Data.Models;
using Pl_Portal.Validator;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
           _bookService = bookService;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _bookService.GetBookList());
              //return _bookService.GetBookList != null ? 
              //            View(await _bookService.GetBookList().ConfigureAwait(false)) :
              //            Problem(nameof(Index));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _bookService.GetBookList == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,NumberOfPages,Format,YearOfPublication,IsDeleted")] Book book)
        {
            var BookValidator = new BookValidator();
            var validationResult = BookValidator.Validate(book);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(book);
            }
            else if (ModelState.IsValid)
            {
                await _bookService.Create(book);
                //return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
            //return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _bookService.GetBookList == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,NumberOfPages,Format,YearOfPublication,IsDeleted,Id")] Book book)
        {
            if (book == null || id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.Update(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _bookService.GetBookList == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_bookService.GetBookList == null)
            {
                return Problem("Entity set 'WebApplication1Context.Book'  is null.");
            }
            var book = await _bookService.GetBookById(id);
            if (book != null)
            {
                await _bookService.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int? id)
        {
          return _bookService.GetBookById(id) != null ? true : false;
        }
    }
}
