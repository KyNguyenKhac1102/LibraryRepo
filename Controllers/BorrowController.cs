

using System.Collections.Generic;
using LibraryApp.Dtos;
using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _service;

        public BorrowController(IBorrowService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<BorrowRequestDto> getAllRequest()
        {

            return _service.getAllRequest();

        }
        [HttpPost("request")]
        public IActionResult CreateRequest(int userId, int userRequestCount)
        {
            if (userRequestCount > 3)
            {
                return BadRequest(new { message = "No more new request till next month" });
            }
            _service.createRequest(userId);
            return Ok(new { message = "success" });
        }

        [HttpPost("detail")]
        public IActionResult CreateDetail(int requestId, int[] listBookId)
        {
            if (listBookId.Length > 5)
            {
                return BadRequest(new { message = "No more than 5 books" });
            }

            _service.createDetailRequest(requestId, listBookId);
            return Ok(new { message = "success" });
        }

        [HttpPost("status")]
        public IActionResult UpdateStatus(int requestId, int userId, Status status)
        {
            _service.updateStatus(requestId, userId, status);
            return Ok(new { message = "success" });
        }
    }
}