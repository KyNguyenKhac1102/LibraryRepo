

using System.Collections.Generic;
using LibraryApp.Context;
using LibraryApp.Models;
using System.Linq;
using LibraryApp.Dtos;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;
        public BookService(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> getAll()
        {
            return await _context.Books.ToListAsync();

        }
        public void Create(BookDto dto)
        {
            var book = new Book
            {
                BookName = dto.BookName,

            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }


        public void Update(int id, BookDto dto)
        {
            var BookUpdate = _context.Books.Find(id);
            BookUpdate.BookName = dto.BookName;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var deleteBook = _context.Books.Find(id);
            _context.Remove(deleteBook);
            _context.SaveChanges();

        }


    }
}