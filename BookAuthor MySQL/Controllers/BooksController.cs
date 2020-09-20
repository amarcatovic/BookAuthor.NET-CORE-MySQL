using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookAuthor_MySQL.Data.Dtos;
using BookAuthor_MySQL.Data.Models;
using BookAuthor_MySQL.Data.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthor_MySQL.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookRepo _repo;

        public BooksController(IMapper mapper, IBookRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var bookFromDb = await _repo.GetBookById(id);

            if (bookFromDb == null)
                return NotFound("Book was not found!");

            var bookReadDto = _mapper.Map<BookReadDto>(bookFromDb);
            return Ok(bookReadDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var booksFromDb = await _repo.GetBooks();
            if (booksFromDb.Count() == 0)
                return NoContent();

            var booksReadDto = _mapper.Map<IEnumerable<BookReadDto>>(booksFromDb);
            return Ok(booksReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookCreateDto bookCreateDto)
        {
            var book = _mapper.Map<Book>(bookCreateDto);
            await _repo.CreateBook(book);

            if(await _repo.Done())
            {
                var bookReadDto = _mapper.Map<BookReadDto>(book);
                return CreatedAtRoute(nameof(GetBookById), new { id = bookReadDto.Id }, bookReadDto);
            }

            return BadRequest();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBook(int id, JsonPatchDocument<BookPatchDto> jsonPatchDocument)
        {
            var bookFromDb = await _repo.GetBookById(id);
            if (bookFromDb == null)
                return BadRequest();

            var bookPatch = _mapper.Map<BookPatchDto>(bookFromDb);
            jsonPatchDocument.ApplyTo(bookPatch);
            if (!TryValidateModel(bookPatch))
                return ValidationProblem();

            _mapper.Map(bookPatch, bookFromDb);
            if (await _repo.Done())
                return NoContent();

            return BadRequest();
        }
    }
}