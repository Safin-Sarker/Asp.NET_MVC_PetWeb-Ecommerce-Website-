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
    }
}
