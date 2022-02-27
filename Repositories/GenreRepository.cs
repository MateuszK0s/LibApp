using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using System.Collections.Generic;

namespace LibApp.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genre;
        }
    }
}