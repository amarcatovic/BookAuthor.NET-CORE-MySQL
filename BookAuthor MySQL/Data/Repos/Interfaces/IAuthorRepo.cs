using BookAuthor_MySQL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Repos.Interfaces
{
    public interface IAuthorRepo
    {
        Task<Author> GetAuthorById(int id);
        Task<IEnumerable<Author>> GetAuthors();
        Task CreateAuthor(Author author);
    }
}
