using Microsoft.EntityFrameworkCore;

namespace filmsRESTapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=omen;Database=FilmsDB;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<Films> Films { get; set; }
    }
}
