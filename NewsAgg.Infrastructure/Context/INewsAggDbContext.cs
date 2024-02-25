using Microsoft.EntityFrameworkCore;
using NewsAgg.Domain;

namespace NewsAgg.Infrastructure.Context
{
    public interface INewsAggDbContext
    {
        DbSet<NewsFeed> NewsFeeds { get; set; }
    }
}
