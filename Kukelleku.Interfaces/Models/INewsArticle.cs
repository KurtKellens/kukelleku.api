namespace Kukelleku.Interfaces.Models
{
    public interface INewsArticle
    {
        string Title { get; }
        string Description { get; }
        string Link { get; }
        DateTime Published { get; }
        string? Image { get; }
    }
}
