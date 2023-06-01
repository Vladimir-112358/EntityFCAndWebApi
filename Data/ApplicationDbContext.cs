using Microsoft.EntityFrameworkCore;

namespace EntityFCAndWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Models.Products> Products { get; set; }
        public DbSet<Models.Storages> Storages { get; set; }
        public DbSet<Models.StatesOfStorages> StatesOfStorages { get; set; }


        // Class OnConfiguring is used for settings context's class
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=StorageDB; Encrypt=False;User ID=sa;Password=1234");

            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
