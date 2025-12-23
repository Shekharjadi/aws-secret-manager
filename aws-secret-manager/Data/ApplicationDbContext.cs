using aws_secret_manager.Models;
using Microsoft.EntityFrameworkCore;


namespace AwsSecretManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }
    }
}
