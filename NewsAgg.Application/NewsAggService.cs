using NewsAgg.Domain;

namespace NewsAgg.Application
{
    public class NewsAggService : INewsAggService
    {
        private readonly INewsAggRepository newsAggRepository;
        // Constructor dependency injection
        public NewsAggService(INewsAggRepository newsAggRepository)
        {
            this.newsAggRepository = newsAggRepository;
        }

        public List<NewsFeed> GetAllNewsFeeds()
        {
            return newsAggRepository.GetAllNewsFeeds();
        }
        public async Task<List<NewsFeed>> GetAllNewsAsync()
        {
            return await newsAggRepository.GetAllNewsAsync();
        }

        public async Task<List<NewsFeed>> FindNewsFeedByTitle(string searchLine)
        {
            return await newsAggRepository.FindNewsFeedByTitle(searchLine);
        }

        public async Task<List<NewsFeed>> FindNewsFeedByDescription(string searchLine)
        {
            return await newsAggRepository.FindNewsFeedByDescription(searchLine);
        }

        public async Task<List<NewsFeed>> FindNewsFeedByTitleAndDescription(string searchLine)
        {
            return await newsAggRepository.FindNewsFeedByTitleAndDescription(searchLine);
        }


        public NewsFeed CreateNewsFeed(NewsFeed newsFeed)
        {
            return newsAggRepository.CreateNewsFeed(newsFeed);
        }
        public async Task<NewsFeed> CreateNewsFeedAsync(NewsFeed newsFeed)
        {
            return await newsAggRepository.CreateNewsFeedAsync(newsFeed);
        }
        public async Task<int> CreateNewsFeeds(string requestLink)
        {
            return await newsAggRepository.CreateNewsFeeds(requestLink);
        }
    }
}
