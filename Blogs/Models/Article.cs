using System;

// Models/Article.cs
namespace ArticleFetcher.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string img { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
