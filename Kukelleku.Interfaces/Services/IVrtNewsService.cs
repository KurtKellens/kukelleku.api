using Kukelleku.Interfaces.Models;

namespace Kukelleku.Interfaces.Services
{
    public interface IVrtNewsService
    {
        Task<IReadOnlyCollection<INewsArticle>?> GetArticles();
    }
}
