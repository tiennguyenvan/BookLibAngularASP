using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private IBookService _service;

		public BookController(IBookService service) {
			_service = service;
		}

		// add/create a new book
		[HttpPost]
        public IActionResult CreateBook([FromBody] Book book) {
            _service.AddBook(book);
            return Ok("Added");
        }

		// get all books
		[HttpGet]
        public IActionResult GetBooks() {
            return Ok(_service.GetAllBooks());
        }
    }
}