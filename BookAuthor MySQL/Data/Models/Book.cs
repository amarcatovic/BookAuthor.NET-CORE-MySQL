using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public ICollection<AuthorBook> BookAuthors { get; set; }
    }
}
