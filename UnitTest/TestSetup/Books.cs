using BookStore.DBOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.TestSetup
{
    public static class Books
    {
        public static void AddBooks (this BookStoreDbContext Context)
        {
            {
                Context.Books.AddRange(
               new Book()
               {
                   Id = 1,
                   Title = "Lean Startup",
                   GenreID = 1, // Personal Growth
                   PageCount = 200,
                   PublishDate = new DateTime(2001, 06, 12)

               },
               new Book
               {
                   Id = 2,
                   Title = "Herland",
                   GenreID = 2, // science fiction
                   PageCount = 250,
                   PublishDate = new DateTime(2010, 05, 23)
               },
               new Book
               {
                   Id = 3,
                   Title = "Dune",
                   GenreID = 2, // science fiction
                   PageCount = 540,
                   PublishDate = new DateTime(2001, 12, 21)
               });
            } }
    }
}
