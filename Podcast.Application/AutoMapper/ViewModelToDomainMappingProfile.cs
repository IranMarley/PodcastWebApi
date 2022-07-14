using AutoMapper;
using Podcast.Application.Models;
using Podcast.Domain.Entities;

namespace Podcast.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PodcastModel, PodcastEntity>();
            CreateMap<PodcastFilterModel, PodcastFilter>();
        }
    }
}
