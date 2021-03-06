﻿using BookAuthor_MySQL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Dtos
{
    public class AuthorReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<BookBasicReadDto> Books { get; set; }
    }
}
