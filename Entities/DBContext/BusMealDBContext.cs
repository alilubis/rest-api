using Microsoft.EntityFrameworkCore;

namespace RestAPI.Entities.DBContext
{
    public class BusMealDBContext : DbContext
    {
       public BusMealDBContext(DbContextOptions<BusMealDBContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>().ToTable("Department");
        }
    }
}