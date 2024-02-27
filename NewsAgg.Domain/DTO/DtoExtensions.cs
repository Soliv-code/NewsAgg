namespace NewsAgg.Domain.DTO
{
    public static class DtoExtensions
    {
        public static NewsFeedDto toDto(this NewsFeed newsFeed)
        {
            return new NewsFeedDto(
                newsFeed.Id,
                newsFeed.Title,
                newsFeed.Description,
                newsFeed.Link,
                newsFeed.PubDate
            );
        }
    }
}
