using Kukelleku.Interfaces.Configuration;

namespace Kukelleku.api.Configuration
{
    public class VrtNewsConfiguration : IVrtNewsConfiguration
    {
        public string FeedUrl { get; set; }
    }
}