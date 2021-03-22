using Amazon.Suporte.Model;
using Microsoft.EntityFrameworkCore;
namespace Amazon.Suporte.Database
{
    public class SupportDBContext : DbContext
    {
        public SupportDBContext(DbContextOptions<SupportDBContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {}

        public DbSet<Problem> Problem { get; set; }
    }
}
