using Microsoft.EntityFrameworkCore;
using NewsAgg.Application;
using NewsAgg.Domain;
using NewsAgg.Infrastructure.Context;

namespace NewsAgg.Infrastructure.Plugins
{
    public class NewsAggRepository : INewsAggRepository
    {
        public static List<NewsFeed> newsfeeds = new List<NewsFeed>()
        {
            new NewsFeed {Title = "title 1", Description = "description 1", Link = "https:\\google.com", PubDate = new DateTime()},
            new NewsFeed {Title = "title 2", Description = "description 2", Link = "https:\\yandex.ru", PubDate = new DateTime().AddDays(1)},
            new NewsFeed {Title = "title 3", Description = "description 3", Link = "https:\\yahoo.com", PubDate = new DateTime().AddDays(2)},
            new NewsFeed {Title = "title 4", Description = "description 4", Link = "https:\\rambler.com", PubDate = new DateTime().AddDays(3)},
        };
        private readonly NewsAggDbContext _newsAggDbContext;

        public NewsAggRepository(NewsAggDbContext newsAggDbContext)
        {
            _newsAggDbContext = newsAggDbContext;
        }
        public List<NewsFeed> GetAllNewsFeeds()
        {
            var newsFeeds = _newsAggDbContext.NewsFeeds.ToList();
            return newsFeeds;
        }
        public NewsFeed CreateNewsFeed(NewsFeed newsFeed)
        {

            _newsAggDbContext.NewsFeeds.Add(newsFeed);
            if (_newsAggDbContext.SaveChanges() > 0)
                return newsFeed;
            else
                return null;
        }

        public int CreateNewsFeeds(List<NewsFeed> newsFeed)
        {
            throw new NotImplementedException();
        }
    }
}
