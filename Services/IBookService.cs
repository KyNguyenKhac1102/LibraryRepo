
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> getAll();

        void Create(BookDto dto);
        void Update(int id, BookDto dto);
        void Delete(int id);

    }
}