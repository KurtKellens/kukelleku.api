using Kukelleku.Interfaces.Configuration;
using Kukelleku.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Kukelleku.Services.Startup
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            // Register the services here
            builder.Services.AddTransient(
                typeof(IVrtNewsService), 
                (sp) => {
                    var newsConfiguration = sp.GetRequiredService<INewsConfiguration>();
                    return new VrtNewsService(newsConfiguration.VrtNews); 
                }
            );

        }
    }
}
