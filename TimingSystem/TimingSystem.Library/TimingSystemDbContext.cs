using Microsoft.EntityFrameworkCore;
using TimingSystem.Library.Tables;

namespace TimingSystem.Library
{
    public class TimingSystemDbContext : DbContext
    {
        public DbSet<Time> Times { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public string DbPath { get; } = "C:\\Users\\JD\\Documents\\GitHub\\TimingSystem\\Data\\TimingSystemDb.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseSqlite($"Data Source=\"{DbPath}\"");
        }
    }
}
