using System.ComponentModel.DataAnnotations;

namespace NewsAgg.Domain.DTO
{
    public record NewsFeedDto(
        int Id,
        string Title,
        string? Description,
        string? Link,
        DateTime? PubDate
    );
    public record CreateNewsFeedDto(
        string Title,
        string? Description,
        string? Link,
        DateTime? PubDate
    );
}
