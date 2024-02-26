using NewsAgg.Domain;

namespace NewsAgg.Application
{
    public interface INewsAggService
    {
        List<NewsFeed> GetAllNewsFeeds();
        Task<List<NewsFeed>> GetAllNewsAsync();
        Task<List<NewsFeed>> FindNewsFeedByTitle(string searchLine);
        Task<List<NewsFeed>> FindNewsFeedByDescription(string searchLine);
        Task<List<NewsFeed>> FindNewsFeedByTitleAndDescription(string searchLine);

        NewsFeed CreateNewsFeed(NewsFeed newsFeed);
        Task<NewsFeed> CreateNewsFeedAsync(NewsFeed newsFeed);
        Task<int> CreateNewsFeeds(string requestLink);
    }
}
