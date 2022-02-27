using AutoMapper;
using LibApp.Dtos;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks(string query = null)
        {
            var booksQuery = _bookRepository.GetAvailableBooksBy(query);

            return Ok(booksQuery.ToList().Select(_mapper.Map<Book, BookDto>));
        }

        // POST /api/books/
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            _bookRepository.AddBook(book);
            _bookRepository.SaveChanges();

            return Ok(_mapper.Map<BookDto>(book));
        }

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.SingleOrDefault(id);

            if (book == null)
            {
                return NotFound("Book not found.");
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        // PUT api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            var bookInDb = _bookRepository.GetBookById(id);

            if (bookInDb == null)
            {
                return NotFound("Book not found.");
            }

            bookInDb.Name = book.Name;
            bookInDb.AuthorName = book.AuthorName;
            bookInDb.GenreId = book.GenreId;
            bookInDb.ReleaseDate = book.ReleaseDate;
            bookInDb.NumberInStock = book.NumberInStock;
            bookInDb.NumberAvailable = book.NumberAvailable;

            _bookRepository.SaveChanges();

            return Ok(_mapper.Map<BookDto>(bookInDb));
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepository.DeleteBookById(id);
            _bookRepository.SaveChanges();

            return NoContent();
        }
    }
}