using AutoMapper;
using Podcast.Application.Interfaces;
using Podcast.Application.Models;
using Podcast.Domain.Entities;
using Podcast.Domain.Interfaces;
using Podcast.Infra.CrossCutting.Support;

namespace Podcast.Application.Services
{
    public class PodcastService : IPodcastService
    {
        private readonly IMapper _mapper;
        private readonly IPodcastRepository _podcastRepository;

        public PodcastService(IMapper mapper,
                              IPodcastRepository podcastRepository)
        {
            _mapper = mapper;
            _podcastRepository = podcastRepository;
        }

        public IEnumerable<PodcastModel> GetAll(PodcastFilterModel filterModel, Pagination pagination)
        {
            var filter = _mapper.Map<PodcastFilter>(filterModel);

            return _mapper.Map<IEnumerable<PodcastModel>>(_podcastRepository.GetAll(filter, pagination));
        }

        public int Count(PodcastFilterModel filterModel)
        {
            var filter = _mapper.Map<PodcastFilter>(filterModel);
            return _podcastRepository.Count(filter);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
