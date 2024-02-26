using Microsoft.EntityFrameworkCore;
using NewsAgg.Domain;
using NewsAgg.Infrastructure.Additions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;

namespace NewsAgg.Infrastructure.Context
{
    public class NewsAggDbContext : DbContext, INewsAggDbContext
    {
        public NewsAggDbContext(DbContextOptions<NewsAggDbContext> options)
            : base(options)
        {

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<NewsFeed> NewsFeeds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityAlwaysColumns();
            foreach (var ent in modelBuilder.Model.GetEntityTypes())
            {
                ent.SetTableName(ent.GetTableName().ToSnakeCase());
            }
        }
    }
}
