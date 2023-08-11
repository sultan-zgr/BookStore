using BookStore.Application.BookOperations.Commands.CreateBook;
using BookStore.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.TestSetup;
using Xunit;
using static BookStore.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UnitTest.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord of the Rings", 0, 0)]
        [InlineData("Lord of the Rings", 0, 1)]
        [InlineData("Lord of the Rings", 1, 0)]
        [InlineData("Lo", 0, 0)]
        [InlineData("", 110, 1)]
        [InlineData(" ", 100000, 21)]
        public void WhenInValidInputAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
        {
            //Arrenge
            CreateBookCommand command = new CreateBookCommand(null,null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreID = genreId,
       
            };



            //act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null,null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreID = 1,
               
            };
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
    }
