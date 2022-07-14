using Podcast.Application.Models;
using Podcast.Infra.CrossCutting.Support;

namespace Podcast.Application.Interfaces
{
    public interface IPodcastService : IDisposable
    {
        IEnumerable<PodcastModel> GetAll(PodcastFilterModel filter, Pagination pagination);
        int Count(PodcastFilterModel filter);
    }
}
