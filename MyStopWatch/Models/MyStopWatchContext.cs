using Microsoft.EntityFrameworkCore;

namespace MyStopWatch.Models
{
    internal class MyStopWatchContext : DbContext
    {
        public DbSet<Work> Works { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Data Source={Path.Combine(Program.SaveDir(), $"{Program.ProjectName()}.db")}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Work>().HasData(new Work { Id = 1, Title = "Sample" });
        }
    }
}
