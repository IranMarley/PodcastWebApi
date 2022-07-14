using Xunit;

namespace Podcast.Tests.IntegrationTest
{
    public class PodcastsControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public PodcastsControllerIntegrationTests(TestingWebAppFactory<Program> factory)
            => _httpClient = factory.CreateClient();

        [Fact]
        public async Task DefaultRoute_Returns_Error()
        {
            var response = await _httpClient.GetAsync("");
            var stringResult = await response.Content.ReadAsStringAsync();
            Assert.Equal("", stringResult);
        }

        [Fact]
        public async Task Podcast_Returns_Json()
        {
            var response = await _httpClient.GetAsync("/podcasts");
            var stringResult = await response.Content.ReadAsStringAsync();

            Assert.Contains("pageNumber", stringResult);
        }
    }
}
