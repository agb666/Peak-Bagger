using Microsoft.EntityFrameworkCore;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Peak> Peaks => Set<Peak>();

        public DbSet<Area> Areas => Set<Area>();

        public DbSet<Country> Countries => Set<Country>();

        public DbSet<Tag> Tags => Set<Tag>();

        public DbSet<PeakTag> PeakTags => Set<PeakTag>();

        public DbSet<TrigPointType> TrigPointTypes => Set<TrigPointType>();

        public DbSet<Bagged> Bagged => Set<Bagged>();
    }

}