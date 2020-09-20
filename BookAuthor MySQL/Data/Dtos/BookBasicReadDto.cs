using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Dtos
{
    public class BookBasicReadDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
    }
}
