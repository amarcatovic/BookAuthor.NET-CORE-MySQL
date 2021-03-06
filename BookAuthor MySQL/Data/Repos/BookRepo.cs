﻿using BookAuthor_MySQL.Data.Models;
using BookAuthor_MySQL.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Repos
{
    public class BookRepo : IBookRepo
    {
        private readonly DataContext _context;

        public BookRepo(DataContext context)
        {
            _context = context;
        }
        public async Task CreateBook(Book book, IEnumerable<int> authorIds)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            foreach(var author in authorIds)
            {
                _context.AuthorBook.Add(new AuthorBook() { AuthorId = author, BookId = book.Id });
            }
        }

        public async Task<Book> GetBookById(int id)
        {
            var bookFromDb = await _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .SingleOrDefaultAsync(b => b.Id == id);

            return bookFromDb;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var booksFromDb = await _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .ToListAsync();

            return booksFromDb;
        }

        public async Task<bool> Done()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}
