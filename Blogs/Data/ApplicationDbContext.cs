// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using ArticleFetcher.Models;

namespace ArticleFetcher.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
