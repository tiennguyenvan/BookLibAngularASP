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
            return Ok();
        }

		// get all books
		[HttpGet]
        public IActionResult GetBooks() {
			Console.WriteLine("Get all books");
            return Ok(_service.GetAllBooks());
        }

		// getting a book by id
		[HttpGet("{id}")]
        public IActionResult GetBookById(int id) {
			Console.WriteLine("searching for id: " + id);
			var book = _service.GetBookById(id);
			if (book == null) {
                return NotFound();
            }
			return Ok(book);
		}

		// updating existing book
		[HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book) {
            _service.UpdateBook(id, book);
            return Ok(book);
        }

		// deleting a book
		[HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) {
            _service.DeleteBook(id);
            return Ok();
        }
    }
}