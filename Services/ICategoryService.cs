
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> getAll();
        void Create(CategoryDto dto);
        void Update(int id, CategoryDto dto);
        void Delete(int id);

    }
}