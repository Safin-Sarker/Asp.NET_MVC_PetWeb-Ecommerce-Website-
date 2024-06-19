using Microsoft.EntityFrameworkCore;
using PetWeb.Models;

namespace PetWeb.Data
{
    public class ApplicationDbContext1:DbContext
    {
        public ApplicationDbContext1(DbContextOptions<ApplicationDbContext1> options)
           : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Action", DisplayOrder=1},
                new Category { Id = 2, Name = "Scify", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            
        }
    }
}
