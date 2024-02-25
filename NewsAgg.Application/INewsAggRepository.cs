using NewsAgg.Domain;

namespace NewsAgg.Application
{
    public interface INewsAggRepository
    {
        List<NewsFeed> GetAllNewsFeeds();
        NewsFeed CreateNewsFeed(NewsFeed newsFeed);
        int CreateNewsFeeds(List<NewsFeed> newsFeed);
    }
}
