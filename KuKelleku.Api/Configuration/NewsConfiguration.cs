using Kukelleku.Interfaces.Configuration;

namespace Kukelleku.api.Configuration
{
    public class NewsConfiguration : INewsConfiguration
    {
        public NewsConfiguration()
        {
            VrtNews= new VrtNewsConfiguration();
        }
        public IVrtNewsConfiguration VrtNews { get; set; } 
    }
}
