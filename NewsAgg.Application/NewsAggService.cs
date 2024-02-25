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
        public NewsFeed CreateNewsFeed(NewsFeed newsFeed)
        {
            return newsAggRepository.CreateNewsFeed(newsFeed);
        }

        public int CreateNewsFeeds(List<NewsFeed> newsFeed)
        {
            return newsAggRepository.CreateNewsFeeds(newsFeed);
        }

    }
}
