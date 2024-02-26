using Microsoft.EntityFrameworkCore;
using NewsAgg.Application;
using NewsAgg.Domain;
using NewsAgg.Infrastructure.Additions;
using NewsAgg.Infrastructure.Context;

namespace NewsAgg.Infrastructure.Plugins
{
    public class NewsAggRepository : INewsAggRepository
    {
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
        public async Task<List<NewsFeed>> GetAllNewsAsync()
        {
            var newsFeeds = await _newsAggDbContext.NewsFeeds.ToListAsync();
            return newsFeeds;
        }
        public async Task<List<NewsFeed>> FindNewsFeedByTitle(string searchLine)
        {
            if (searchLine is null || searchLine == string.Empty)
                return await _newsAggDbContext.NewsFeeds.ToListAsync();
            else
                return await _newsAggDbContext.NewsFeeds.Where(n => n.Title.Contains(searchLine)).OrderByDescending(n => n.PubDate).ToListAsync();
        }
        public async Task<List<NewsFeed>> FindNewsFeedByDescription(string searchLine)
        {
            if (searchLine is null || searchLine == string.Empty)
                return await _newsAggDbContext.NewsFeeds.ToListAsync();
            else
                return await _newsAggDbContext.NewsFeeds.Where(n => n.Description.Contains(searchLine)).OrderByDescending(n => n.PubDate).ToListAsync();
        }

        public async Task<List<NewsFeed>> FindNewsFeedByTitleAndDescription(string searchLine)
        {
            if (searchLine is null || searchLine == string.Empty)
                return await _newsAggDbContext.NewsFeeds.ToListAsync();
            else
                return await _newsAggDbContext.NewsFeeds.Where(n => 
                n.Title.Contains(searchLine) || 
                n.Description.Contains(searchLine)).OrderByDescending(n => n.PubDate).ToListAsync();
        }


        public NewsFeed CreateNewsFeed(NewsFeed newsFeed)
        {
            _newsAggDbContext.NewsFeeds.Add(newsFeed);
            if (_newsAggDbContext.SaveChanges() > 0)
                return newsFeed;
            else
                return new NewsFeed();
        }
        public async Task<NewsFeed> CreateNewsFeedAsync(NewsFeed newsFeed)
        {
            _newsAggDbContext.NewsFeeds.Add(newsFeed);
            await _newsAggDbContext.SaveChangesAsync();
            return newsFeed ?? new NewsFeed();
        }
        public async Task<int> CreateNewsFeeds(string requestLink)
        {
            if (!AdditionalMethods.IsLink(requestLink)) return 0;
            var iCountAddEntites = 0;
            //TODO: RSS Validation
            var newsfeed = AdditionalMethods.ParsUrl(requestLink);
            foreach (var nf in newsfeed)
            {
                _newsAggDbContext.NewsFeeds.Add(nf);
                iCountAddEntites += await _newsAggDbContext.SaveChangesAsync();
            }
            return iCountAddEntites;
        }
    }
}
