using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using System.Collections.Generic;

namespace LibApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            _context.Books.Remove(GetBookById(bookId));
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.Find(1);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books;
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}