using BookAuthor_MySQL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Repos.Interfaces
{
    public interface IBookRepo
    {
        Task<Book> GetBookById(int id);
        Task<IEnumerable<Book>> GetBooks();
        Task CreateBook(Book book, IEnumerable<int> authorIds);

        Task<bool> Done();
    }
}
