using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Context
{
    public class TestContext : DbContext
    {
        private IConfiguration Configuration { get; }

        public TestContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetSection("TestConnetionString").Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Truck>()
                .HasIndex(r => r.Code).IsUnique();

            modelBuilder.Entity<Truck>().ToTable("Trucks");
        }
    }
}
