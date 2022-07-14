using AutoMapper;
using Podcast.Application.Models;
using Podcast.Domain.Entities;

namespace Podcast.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PodcastEntity, PodcastModel>();
            CreateMap<PodcastFilter, PodcastFilterModel>();
        }
    }
}
