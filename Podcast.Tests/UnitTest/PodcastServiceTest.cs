using AutoMapper;
using Moq;
using Podcast.Application.AutoMapper;
using Podcast.Application.Models;
using Podcast.Application.Services;
using Podcast.Domain.Entities;
using Podcast.Domain.Interfaces;
using Podcast.Infra.CrossCutting.Support;
using Xunit;

namespace Podcast.Tests.UnitTest
{
    public class PodcastServiceTest
    {
        #region Fields 

        private static IMapper _mapper;
        private readonly Mock<IPodcastRepository> _mockPodcastRepository;
        private readonly PodcastService _podcastService;

        #endregion End Fields 

        #region Constructor

        public PodcastServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new DomainToViewModelMappingProfile());
                    mc.AddProfile(new ViewModelToDomainMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _mockPodcastRepository = new Mock<IPodcastRepository>();
            _podcastService = new PodcastService(_mapper, _mockPodcastRepository.Object);
        }

        #endregion Constructor

        #region Tests

        [Fact]
        public void GetAll_Should_Bring_List()
        {
            //Arrange
            _mockPodcastRepository
                .Setup(x => x.GetAll())
                .Returns(MockPodcastEntity);

            //Act
            var result = _podcastService.GetAll();

            //Assert
            Assert.Collection(result, 
                             item => Assert.Contains("Alexa", item.title),
                             item => Assert.Contains("Week", item.title));
        }

        [Fact]
        public void Get_Should_Bring_Paginated()
        {
            //Arrange
            _mockPodcastRepository
                .Setup(x => x.Get(It.IsAny<PodcastFilter>(), It.IsAny<Pagination>()))
                .Returns(MockPodcastEntity);

            //Act
            var result = _podcastService.Get(new PodcastFilterModel(), new Pagination());

            //Assert
            Assert.Collection(result,
                             item => Assert.Contains("Alexa", item.title),
                             item => Assert.Contains("Week", item.title));
        }

        [Fact]
        public void Count_Should_Bring_Total_Podcasts()
        {
            //Arrange
            _mockPodcastRepository
                .Setup(x => x.Count(It.IsAny<PodcastFilter>()))
                .Returns(MockPodcastEntity.Count());

            //Act
            var result = _podcastService.Count(new PodcastFilterModel());

            //Assert
            Assert.Equal(2, result);
        }

        #endregion End Tests


        #region Mocks

        private IEnumerable<PodcastEntity> MockPodcastEntity
            => new List<PodcastEntity>
            {
                new PodcastEntity
                {
                    id = "49b3e8357a644abfa6d45b95b57a5637",
                    title = "Alexa Stop Podcast",
                    publisher = "Robert Belgrave & Jim Bowes",
                    description = "Two technology CEOs \u2014 Jim Bowes and Robert Belgrave \u2014 discuss how technology is changing our lives, joined every month by a special guest from the industry. Supported by D/SRUPTION Magazine.",
                    genre_ids = new List<int>{ 140, 67, 127}
                },
                 new PodcastEntity
                {
                    id = "33bd629683d6413fae3dcc6d434c63a4",
                    title = "This Week in Tech (MP3)",
                    publisher = "TWiT",
                    description = "Your first podcast of the week is the last word in tech. Join the top tech pundits in a roundtable discussion of the latest trends in high tech.\n\nRecords live every Sunday at 5:15pm Eastern / 2:15pm Pacific / 21:15 UTC.",
                    genre_ids = new List<int>{ 149, 157, 127, 140, 67, 93, 95, 99, 130, 131}
                },
            };

        #endregion Mocks
    }
}
