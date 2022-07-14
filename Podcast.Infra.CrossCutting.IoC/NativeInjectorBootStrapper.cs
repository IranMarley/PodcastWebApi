using Podcast.Application.Interfaces;
using Podcast.Application.Services;
using Podcast.Domain.Interfaces;
using Podcast.Infra.CrossCutting.Support;
using Podcast.Infra.Data.Context;
using Podcast.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Podcast.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IPodcastService, PodcastService>();

            // Infra - Data
            services.AddScoped<IPodcastRepository, PodcastRepository>();
            services.AddScoped<ApiContext>();

            // CrossCutting - Support
            services.AddScoped<Pagination>();
        }
    }
}
