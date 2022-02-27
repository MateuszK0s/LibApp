using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class CustomSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                if (!context.Genre.Any())
                {
                    context.Genre.AddRange(
                        new Genre
                        {
                            Name = "Fantasy"
                        },
                        new Genre
                        {
                            Name = "Action"
                        },
                        new Genre
                        {
                            Name = "Dystopia"
                        }
                    );
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Name = "Krew elfów",
                            AuthorName = "Andrzej Sapkowski",
                            GenreId = 1,
                            DateAdded = DateTime.Now,
                            ReleaseDate = new DateTime(1994, 1, 1),
                            NumberInStock = 133,
                            NumberAvailable = 214
                        },
                        new Book
                        {
                            Name = "Harry Potter i Czara Ognia",
                            AuthorName = "J.K. Rowling",
                            GenreId = 2,
                            DateAdded = DateTime.Now,
                            ReleaseDate = new DateTime(2005, 11, 25),
                            NumberInStock = 522,
                            NumberAvailable = 666
                        },
                        new Book
                        {
                            Name = "Rok 1984",
                            AuthorName = "George Orwell",
                            GenreId = 3,
                            DateAdded = DateTime.Now,
                            ReleaseDate = new DateTime(1949, 6, 8),
                            NumberInStock = 4,
                            NumberAvailable = 54
                        }
                    );
                }

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "Adam Małysz",
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 1,
                            Birthdate = new DateTime(1975, 1, 1)
                        },
                        new Customer
                        {
                            Name = "Jerzy Stuhr",
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 2,
                            Birthdate = new DateTime(1968, 1, 1)
                        },
                        new Customer
                        {
                            Name = "Mateusz Kos",
                            HasNewsletterSubscribed = true,
                            MembershipTypeId = 3,
                            Birthdate = new DateTime(1999, 4, 28)
                        }
                    );
                }

                if (!context.Rentals.Any())
                {
                    context.Rentals.AddRange(
                        new Rental
                        {
                            CustomerId = 1,
                            BookId = 1,
                            DateRented = DateTime.Now
                        },
                        new Rental
                        {
                            CustomerId = 2,
                            BookId = 2,
                            DateRented = DateTime.Now
                        },
                        new Rental
                        {
                            CustomerId = 3,
                            BookId = 3,
                            DateRented = DateTime.Now
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}