using NewsAgg.Domain;
using NewsAgg.Domain.DTO;

namespace NewsAgg.Application
{
    public interface INewsAggService
    {
        // List<NewsFeedDto> GetAllNewsFeeds();
        Task<List<NewsFeedDto>> GetAllNewsAsync();
        Task<List<NewsFeedDto>> FindNewsFeedByTitle(string searchLine);
        Task<List<NewsFeedDto>> FindNewsFeedByDescription(string searchLine);
        Task<List<NewsFeedDto>> FindNewsFeedByTitleAndDescription(string searchLine);

        // NewsFeed CreateNewsFeed(NewsFeed newsFeed);
        // Task<NewsFeed> CreateNewsFeedAsync(NewsFeed newsFeed);
        Task<CreateNewsFeedDto?> CreateNewsFeedAsync(CreateNewsFeedDto newsFeedDto);
        Task<int> CreateNewsFeeds(string requestLink);
    }
}
