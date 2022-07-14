using Podcast.Domain.Entities;
using Podcast.Infra.CrossCutting.Support;

namespace Podcast.Domain.Interfaces
{
    public interface IPodcastRepository
    {
       IEnumerable<PodcastEntity> GetAll(PodcastFilter filter, Pagination pagination);
       int Count(PodcastFilter filter);
    }
}
