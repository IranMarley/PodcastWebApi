using Podcast.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Podcast.Infra.Data.Context
{

    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
            LoadPodcasts();
        }

        public IQueryable<PodcastEntity> LoadPodcasts()
        {
            var podcasts = JsonSerializer.Deserialize<IEnumerable<PodcastEntity>>(
                File.ReadAllText("wwwroot/Podcasts.json"))?.ToList() ?? new List<PodcastEntity>();

            var i = 1;
            podcasts.ForEach(f => f.order = i++);

            return podcasts.AsQueryable();
        }

        public DbSet<PodcastEntity> Podcast { get; set; }

    }
}