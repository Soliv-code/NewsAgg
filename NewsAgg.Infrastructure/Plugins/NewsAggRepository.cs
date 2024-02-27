using Microsoft.EntityFrameworkCore;
using NewsAgg.Application;
using NewsAgg.Domain;
using NewsAgg.Domain.DTO;
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
        public List<NewsFeedDto> GetAllNewsFeeds()
        {
            return _newsAggDbContext.NewsFeeds.Select(nf => nf.toDto()).ToList();
        }
        public async Task<List<NewsFeedDto>> GetAllNewsAsync()
        {
            var newsFeeds = await _newsAggDbContext.NewsFeeds.OrderByDescending(n => n.PubDate).Select(x => x.toDto()).ToListAsync();
            return newsFeeds;
        }
        public async Task<List<NewsFeedDto>> FindNewsFeedByTitle(string searchLine)
        {
            if (searchLine is null || searchLine == string.Empty)
                return await _newsAggDbContext.NewsFeeds.OrderBy(n => n.Id).Select(x => x.toDto()).ToListAsync();
            else
                return await _newsAggDbContext.NewsFeeds
                    .Where(n => n.Title.Contains(searchLine))
                    .OrderByDescending(n => n.PubDate)
                    .Select(x => x.toDto()).ToListAsync();
        }
        public async Task<List<NewsFeedDto>> FindNewsFeedByDescription(string searchLine)
        {
            if (searchLine is null || searchLine == string.Empty)
                return await _newsAggDbContext.NewsFeeds.OrderBy(n => n.Id).Select(x => x.toDto()).ToListAsync();
            else
                return await _newsAggDbContext.NewsFeeds
                    .Where(n => n.Description
                    .Contains(searchLine))
                    .OrderByDescending(n => n.PubDate)
                    .Select(x => x.toDto()).ToListAsync();
        }

        public async Task<List<NewsFeedDto>> FindNewsFeedByTitleAndDescription(string searchLine)
        {
            if (string.IsNullOrWhiteSpace(searchLine))
                return await _newsAggDbContext.NewsFeeds.OrderBy(n => n.Id).Select(x => x.toDto()).ToListAsync();
            else
                return await _newsAggDbContext.NewsFeeds.Where(n => 
                n.Title.Contains(searchLine) || 
                n.Description.Contains(searchLine)).OrderByDescending(n => n.PubDate).Select(x => x.toDto()).ToListAsync();
        }

/*
        public NewsFeed CreateNewsFeed(NewsFeed newsFeed)
        {
            _newsAggDbContext.NewsFeeds.Add(newsFeed);
            if (_newsAggDbContext.SaveChanges() > 0)
                return newsFeed;
            else
                return new NewsFeed();
        }
*/
        public async Task<CreateNewsFeedDto?> CreateNewsFeedAsync(CreateNewsFeedDto newsFeedDto)
        {
            NewsFeed newsFeed = new()
            {
                Title = newsFeedDto.Title,
                Description = newsFeedDto.Description,
                Link = newsFeedDto.Link,
                PubDate = newsFeedDto.PubDate,
            };
            _newsAggDbContext.NewsFeeds.Add(newsFeed);
            await _newsAggDbContext.SaveChangesAsync();
            return newsFeedDto;
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
