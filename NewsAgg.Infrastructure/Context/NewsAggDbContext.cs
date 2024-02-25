using Microsoft.EntityFrameworkCore;
using NewsAgg.Domain;

namespace NewsAgg.Infrastructure.Context
{
    public class NewsAggDbContext : DbContext, INewsAggDbContext
    {
        public NewsAggDbContext(DbContextOptions<NewsAggDbContext> options)
            : base(options)
        {

        }
        public DbSet<NewsFeed> NewsFeeds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityAlwaysColumns();
        }
    }
}
