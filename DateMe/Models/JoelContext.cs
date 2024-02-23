using Microsoft.EntityFrameworkCore;
using Mission06_Gatherum.Models;

namespace Mission06_Gatherum.Models
{
    // Represents the database context for Joel's application, responsible for interacting with the database
    public class JoelContext : DbContext
    {
        // Constructor to initialize the context with options
        public JoelContext(DbContextOptions<JoelContext> options) : base(options)
        {

        }

        // Represents the Movies table in the database
        public DbSet<Movie> Movies { get; set; }

        // Represents the Categories table in the database
        public DbSet<Category> Categories { get; set; }

        // Method to configure the initial data for Categories table
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed data 
        {

            modelBuilder.Entity<Category>().HasData(

                    new Category { CategoryId = 1, category = "Miscellaneous" },
                    new Category { CategoryId = 2, category = "Drama" },
                    new Category { CategoryId = 3, category = "Television" },
                    new Category { CategoryId = 4, category = "Horror/Suspense" },
                    new Category { CategoryId = 5, category = "Comedy" },
                    new Category { CategoryId = 6, category = "Family" },
                    new Category { CategoryId = 7, category = "Action/Adventure" },
                    new Category { CategoryId = 8, category = "VHS" }

                );
        }
    }
}