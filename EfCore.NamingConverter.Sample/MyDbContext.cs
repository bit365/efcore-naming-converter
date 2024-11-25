using Microsoft.EntityFrameworkCore;

namespace EfCore.NamingConverter.Sample
{
    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Database=mydb;Username=postgres;Password=postgres");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddNamingConventions(NamingPolicy.SnakeCaseLower);
        }
    }
}
