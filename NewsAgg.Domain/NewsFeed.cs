﻿using System.ComponentModel.DataAnnotations.Schema;

namespace NewsAgg.Domain
{
    public class NewsFeed
    {
        [Column("id")]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Link { get; set; } = string.Empty;
        public DateTime? PubDate { get; set; }
    }
}
