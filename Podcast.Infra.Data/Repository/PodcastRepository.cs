using Podcast.Domain.Entities;
using Podcast.Domain.Interfaces;
using Podcast.Infra.CrossCutting.Support;
using Podcast.Infra.Data.Context;

namespace Podcast.Infra.Data.Repository
{
    public class PodcastRepository : IPodcastRepository
    {
        protected readonly ApiContext _context;

        public PodcastRepository(ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<PodcastEntity> GetAll(PodcastFilter filter, Pagination pagination)
        {
            //Simulates database access
            var podcasts = _context.LoadPodcasts();

            podcasts = filter.ApplyFilters(podcasts);
            return podcasts.ToPaginated(pagination);
        }

        public int Count(PodcastFilter filter)
        {
            //Simulates database access
            var podcasts = _context.LoadPodcasts();
            return filter.ApplyFilters(podcasts).Count();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
