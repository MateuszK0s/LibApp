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
                            Name = "Novel"
                        },
                        new Genre
                        {
                            Name = "Drama"
                        },
                        new Genre
                        {
                            Name = "Musical"
                        }
                    );
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Name = "W pustyni i w puszczy",
                            AuthorName = "Henryk Sienkiewicz",
                            GenreId = 1,
                            DateAdded = DateTime.Now,
                            ReleaseDate = new DateTime(1911, 1, 1),
                            NumberInStock = 100,
                            NumberAvailable = 250
                        },
                        new Book
                        {
                            Name = "Harry Potter i Kamień Filozoficzny",
                            AuthorName = "J.K. Rowling",
                            GenreId = 2,
                            DateAdded = DateTime.Now,
                            ReleaseDate = new DateTime(2002, 1, 18),
                            NumberInStock = 500,
                            NumberAvailable = 1250
                        },
                        new Book
                        {
                            Name = "Nowy wspaniały świat",
                            AuthorName = "Aldous Huxley",
                            GenreId = 3,
                            DateAdded = DateTime.Now,
                            ReleaseDate = new DateTime(1932, 1, 1),
                            NumberInStock = 50,
                            NumberAvailable = 150
                        }
                    );
                }

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "John Wick",
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 1,
                            Birthdate = new DateTime(1980, 1, 23)
                        },
                        new Customer
                        {
                            Name = "Jan Kowalski",
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 2,
                            Birthdate = new DateTime(1995, 1, 23)
                        },
                        new Customer
                        {
                            Name = "John Huston",
                            HasNewsletterSubscribed = true,
                            MembershipTypeId = 3,
                            Birthdate = new DateTime(1906, 8, 5)
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