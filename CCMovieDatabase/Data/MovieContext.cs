using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CCMovieDatabase.Models;
using System.Reflection;

namespace CCMovieDatabase.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Rating> Ratings { get; set; } = default!;
        public DbSet<ActingCredit> ActingCredits { get; set; } = default!;
        public DbSet<CrewCredit> CrewCredits { get; set; } = default!;
        public DbSet<Article> Articles { get; set; } = default!;
        public DbSet<Character> Characters { get; set; } = default!;
        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var ratings = new List<Rating>
            {
                new Rating { RatingId = 1, Name = "PG-13" },
                new Rating { RatingId = 2, Name = "R" },
                new Rating { RatingId = 3, Name = "G" }
            };
            modelBuilder.Entity<Rating>().HasData(ratings);

            // right here we seed data
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Shrek", ReleaseDate = new DateOnly(2001, 04, 26), Description = "A mean lord exiles fairytale creatures to the swamp of a grumpy ogre, who must go on a quest and rescue a princess for the lord in order to get his land back.", RatingId = 1, ThumbnailURL = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTG_q0A0cypAsXxYlgs5J_554BrcnjeeKExlQE3ZaZUuPYv0fUd" },
                new Movie { Id = 2, Title = "Shrek 2", ReleaseDate = new DateOnly(2002, 04, 26), Description = "Shrek is back baby!", RatingId = 1, ThumbnailURL = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTPx7lW6h0G1O9-npEnVPL07fT74Tp6SFl0i47nxfypyVBcQFdS" },
            };

            modelBuilder.Entity<Movie>().HasData(movies);

            var characters = new List<Character>
            {
                new Character { CharacterId = 1, Name = "Shrek", Description = "Big Green Oaf", MovieId = 1 },
                new Character { CharacterId = 2, Name = "Shrek", Description = "Big Green Oaf", MovieId = 2 },
            };

            modelBuilder.Entity<Character>().HasData(characters);


            var people = new List<Person>
            {
                new Person { FirstName = "Mike", LastName = "Myers", PersonId = 1 },
            };

            modelBuilder.Entity<Person>().HasData(people);

            var actingCredits = new List<ActingCredit>
            {
                new ActingCredit { PersonId = 1, CharacterId = 1, ActingCreditId = 1 },
                new ActingCredit { PersonId = 1, CharacterId = 2, ActingCreditId = 2 },
            };

            modelBuilder.Entity<ActingCredit>().HasData(actingCredits);

            

            // article seed data
            var articles = new List<Article>
            { 
                new Article { ArticleId = 1, Title = "Welcome to CCMovieDatabase", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Slug = "hello_world", CreatedAt = new DateTime(2025, 11, 12), ModifiedAt = new DateTime(2025, 11, 12), Author = "Jesse", ThumbnailUrl = "https://craftypixels.com/placeholder-image/300", ShortDescription = "Lorem Ipsum and stuff", IsFeatured = true },
                new Article { ArticleId = 2, Title = "More Movies Added", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Slug = "hello_world2", CreatedAt = new DateTime(2025, 11, 12), ModifiedAt = new DateTime(2025, 11, 12), Author = "Jesse", ThumbnailUrl = "https://craftypixels.com/placeholder-image/300", ShortDescription = "Lorem Ipsum and stuff", IsFeatured = true },
                new Article { ArticleId = 3, Title = "For the love of movies", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Slug = "hello_world3", CreatedAt = new DateTime(2025, 11, 12), ModifiedAt = new DateTime(2025, 11, 12), Author = "Jesse", ThumbnailUrl = "https://craftypixels.com/placeholder-image/300", ShortDescription = "Lorem Ipsum and stuff", IsFeatured = true },
                new Article { ArticleId = 4, Title = "I wrote this", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Slug = "hello_world4", CreatedAt = new DateTime(2025, 11, 12), ModifiedAt = new DateTime(2025, 11, 12), Author = "Jesse", ThumbnailUrl = "https://craftypixels.com/placeholder-image/300", ShortDescription = "Lorem Ipsum and stuff", IsFeatured = true },
            };

            modelBuilder.Entity<Article>().HasData(articles);


            var categories = new List<Category>()
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Computer Accessories"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Graphics Cards"
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Monitors"
                },
                new Category
                {
                    CategoryId = 4,
                    Name = "Hard Drives"
                }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            var products = new List<Product>()
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Dell Keyboard",
                    Description = "A simple mass produced keyboard",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "RTX 5090",
                    Description = "A very expensive video card",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Dell Widescreen Monitor",
                    Description = "An enterprise widescreen monitor",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 4,
                    Name = "WD Black Edition SSD",
                    Description = "Western Digital Black Edition SSD",
                    CategoryId = 4
                },
            };

            modelBuilder.Entity<Product>().HasData(products);

            modelBuilder.Entity<Category>().Navigation(c => c.Products).AutoInclude();
            modelBuilder.Entity<Product>().Navigation(p => p.Category).AutoInclude();
            modelBuilder.Entity<Movie>().Navigation(m => m.Characters).AutoInclude();
            modelBuilder.Entity<Character>().Navigation(c => c.ActingCredit).AutoInclude();
            modelBuilder.Entity<ActingCredit>().Navigation(a => a.Person).AutoInclude();
            
        }
    }
}
