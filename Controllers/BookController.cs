

using LibraryApp.Dtos;
using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            _service.getAll();
            return Ok(new { message = "success" });
        }

        [HttpPost]
        public IActionResult Create(BookDto dto)
        {
            _service.Create(dto);
            return Ok(new { message = "success" });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, BookDto dto)
        {
            _service.Update(id, dto);
            return Ok(new { message = "success" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok(new { message = "success" });
        }
    }
}