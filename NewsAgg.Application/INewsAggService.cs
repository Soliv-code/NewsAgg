using NewsAgg.Domain;

namespace NewsAgg.Application
{
    public interface INewsAggService
    {
        List<NewsFeed> GetAllNewsFeeds();
        NewsFeed CreateNewsFeed(NewsFeed newsFeed);
        int CreateNewsFeeds(List<NewsFeed> newsFeed);
    }
}
