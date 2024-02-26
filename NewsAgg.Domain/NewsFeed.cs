using System.ComponentModel.DataAnnotations.Schema;

namespace NewsAgg.Domain
{
    public class NewsFeed
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; } = string.Empty;
        [Column("description")]
        public string? Description { get; set; } = string.Empty;
        [Column("link")]
        public string? Link { get; set; } = string.Empty;
        [Column("pubDate")]
        public DateTime? PubDate { get; set; }
    }
}
