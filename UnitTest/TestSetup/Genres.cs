using BookStore.DBOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.TestSetup
{
    public static class Genres
    {
        public static void AddGenres (this BookStoreDbContext Context)
        {
            Context.Genres.AddRange(
                   new Genre
                   {
                       Name = "Personal Growth"
                   },
                   new Genre
                   {
                       Name = "Sciene Fiction"
                   },
                   new Genre
                   {
                       Name = "Romance"
                   }
                   );
        }
    }
}
