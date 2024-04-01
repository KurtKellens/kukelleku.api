using Kukelleku.Interfaces.Models;

namespace Kukelleku.Models
{
    public class NewsArticle : INewsArticle
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Link { get; set; }
        public required DateTime Published { get; set; }
        public string? Image { get; set; }
    }
}
