using NewsAgg.Domain;
using NewsAgg.Domain.DTO;

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
        //TODO: Remove not async methods
/*
        public List<NewsFeedDto> GetAllNewsFeeds()
        {
            return newsAggRepository.GetAllNewsFeeds();
        }
*/
        public async Task<List<NewsFeedDto>> GetAllNewsAsync()
        {
            return await newsAggRepository.GetAllNewsAsync();
        }

        public async Task<List<NewsFeedDto>> FindNewsFeedByTitle(string searchLine)
        {
            return await newsAggRepository.FindNewsFeedByTitle(searchLine);
        }

        public async Task<List<NewsFeedDto>> FindNewsFeedByDescription(string searchLine)
        {
            return await newsAggRepository.FindNewsFeedByDescription(searchLine);
        }
        public async Task<List<NewsFeedDto>> FindNewsFeedByTitleAndDescription(string searchLine)
        {
            return await newsAggRepository.FindNewsFeedByTitleAndDescription(searchLine);
        }

        /*
                public NewsFeed CreateNewsFeed(NewsFeed newsFeed)
                {
                    return newsAggRepository.CreateNewsFeed(newsFeed);
                }
        */
        public async Task<CreateNewsFeedDto?> CreateNewsFeedAsync(CreateNewsFeedDto newsFeedDto)
        {
            return await newsAggRepository.CreateNewsFeedAsync(newsFeedDto);
        }
        public async Task<int> CreateNewsFeeds(string requestLink)
        {
            return await newsAggRepository.CreateNewsFeeds(requestLink);
        }
    }
}
