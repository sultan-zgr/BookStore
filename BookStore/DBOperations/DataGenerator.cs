﻿using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Genres.AddRange(
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

                context.Books.AddRange(
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

                context.SaveChanges(); //DB ye yazılması için
            };
        }
    }
}

