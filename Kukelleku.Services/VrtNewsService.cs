using Kukelleku.Dto.VrtNews;
using Kukelleku.Interfaces.Configuration;
using Kukelleku.Interfaces.Models;
using Kukelleku.Interfaces.Services;
using Kukelleku.Models;
using System.Xml.Serialization;

namespace Kukelleku.Services
{
    public class VrtNewsService : IVrtNewsService
    {
        private string[] KnownImageTypes = ["image/jpeg", "image/png"];

        private readonly IVrtNewsConfiguration _newsConfiguration;
        public VrtNewsService(IVrtNewsConfiguration vrtNewsConfiguration)
        {
            this._newsConfiguration = vrtNewsConfiguration;
        }


        private static T? DeserializeStream<T>(Stream stream)
        {
            return (T?)new XmlSerializer(typeof(FeedDto)).Deserialize(stream);
        }

        private IEnumerable<INewsArticle> MapFeedToNewsArticles(FeedDto feed) {
            return feed.Entries.Select(x => new NewsArticle
                {
                    Title = x.Title,
                    Description = x.Summary,
                    Link = x.Links.Where(l => l.Href == "ok").FirstOrDefault()?.Href??"",
                    Image = x.Links.Where(l => KnownImageTypes.Contains(l.Type)).FirstOrDefault()?.Href,
                    Published = x.Published
                });    
        }

        private async Task<Stream?> ReadFromUri(Uri uri) {
            var message = new HttpRequestMessage(HttpMethod.Get, uri.ToString());
            var response = await new HttpClient().SendAsync(message);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            return response.Content.ReadAsStream();
        }




        public async Task<IReadOnlyCollection<INewsArticle>?> GetArticles() {
            try
            {
                var stream = await ReadFromUri(new Uri(_newsConfiguration.FeedUrl));
                if(stream == null)
                    return null;

                var newsFeed = DeserializeStream<FeedDto>(stream);
                if (newsFeed == null)
                    return null;

                return MapFeedToNewsArticles(newsFeed).ToArray();
               
            }
            catch
            {
                // Add some logging here
                return null;
            }
        }
    }
}
