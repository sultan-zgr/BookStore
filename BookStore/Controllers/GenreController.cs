﻿using AutoMapper;
using BookStore.Application.GenreOperations.Commands.CreateGenre;
using BookStore.Application.GenreOperations.Commands.DeleteGenre;
using BookStore.Application.GenreOperations.Commands.UpdateGenre;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.Application.GenreOperations.Queries.GetGenres;
using BookStore.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetGenre()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreDetailById(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = id;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);

            command.Model = newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
        {

            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = updatedGenre;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {

            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
           
            command.Handle();
            return Ok();

        }

    }
}