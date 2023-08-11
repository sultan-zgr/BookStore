﻿using AutoMapper;
using BookStore.Application.BookOperations.Commands.CreateBook;
using BookStore.DBOperations;
using BookStore.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.TestSetup;
using Xunit;
using static BookStore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace UnitTest.Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldReturn()
        {
            //arrange
            var book = new Book() { Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldReturn", PageCount = 100, PublishDate = new DateTime(1990, 01, 10), GenreID = 1};
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };


            //act
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut!");
        }

        //Çalıştırma ve doğrulama
        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            CreateBookModel model = new CreateBookModel() { Title = "Hobbit", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreID = 1};
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreID.Should().Be(model.GenreID);
      
        }
    }
}
