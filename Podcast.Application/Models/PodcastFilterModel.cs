namespace Podcast.Application.Models
{
    public class PodcastFilterModel
    {
        public string? Title { get; set; }
        public string? Publisher { get; set; }
        public int? Genre_id { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 5;
    }
}
