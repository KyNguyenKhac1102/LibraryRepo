
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Context;
using LibraryApp.Dtos;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly LibraryContext _context;
        public CategoryService(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> getAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public void Create(CategoryDto dto)
        {
            var category = new Category
            {
                CategoryName = dto.CategoryName,
                BookId = dto.BookId,

            };
            _context.Categories.Add(category);
            _context.SaveChanges();

        }

        public void Update(int id, CategoryDto dto)
        {
            var CategoryUpdate = _context.Categories.Find(id);
            CategoryUpdate.CategoryName = dto.CategoryName;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteCategory = _context.Categories.Find(id);
            _context.Remove(deleteCategory);
            _context.SaveChanges();
        }
    }
}