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
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepo _repo;

        public AuthorsController(IMapper mapper, IAuthorRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}", Name = "GetAuthorById")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var authorFromDb = await _repo.GetAuthorById(id);

            if (authorFromDb == null)
                return NotFound("Author was not found!");

            var authorReadDto = _mapper.Map<AuthorReadDto>(authorFromDb);
            return Ok(authorReadDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authorsFromDb = await _repo.GetAuthors();
            if (authorsFromDb.Count() == 0)
                return NoContent();

            var authorReadDto = _mapper.Map<IEnumerable<AuthorReadDto>>(authorsFromDb);
            return Ok(authorReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorCreateDto authorCreateDto)
        {
            var author = _mapper.Map<Author>(authorCreateDto);
            await _repo.CreateAuthor(author);

            if (await _repo.Done())
            {
                var authorReadDto = _mapper.Map<AuthorReadDto>(author);
                return CreatedAtRoute(nameof(GetAuthorById), new { id = authorReadDto.Id }, authorReadDto);
            }

            return BadRequest();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBook(int id, JsonPatchDocument<AuthorPatchDto> jsonPatchDocument)
        {
            var authorFromDb = await _repo.GetAuthorById(id);
            if (authorFromDb == null)
                return BadRequest();

            var authorPatch = _mapper.Map<AuthorPatchDto>(authorFromDb);
            jsonPatchDocument.ApplyTo(authorPatch);
            if (!TryValidateModel(authorPatch))
                return ValidationProblem();

            _mapper.Map(authorPatch, authorFromDb);
            if (await _repo.Done())
                return NoContent();

            return BadRequest();
        }
    }
}