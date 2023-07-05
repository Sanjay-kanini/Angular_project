using APIDay3_OnetoMany.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Models
{
    public class ARContext : DbContext
    {
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public ARContext(DbContextOptions<ARContext> options) : base(options)
        { 

        }



    }
}
