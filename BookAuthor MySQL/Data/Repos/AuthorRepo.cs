using BookAuthor_MySQL.Data.Models;
using BookAuthor_MySQL.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Repos
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly DataContext _context;

        public AuthorRepo(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
        }

        public async Task<bool> Done()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            var authorFromDb = await _context.Authors
                .Include(a => a.AuthorBooks)
                .ThenInclude(ab => ab.Book)
                .SingleOrDefaultAsync(a => a.Id == id);

            return authorFromDb;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var authorsFromDb = await _context.Authors
                .Include(a => a.AuthorBooks)
                .ThenInclude(ab => ab.Book)
                .ToListAsync();

            return authorsFromDb;
        }
    }
}
