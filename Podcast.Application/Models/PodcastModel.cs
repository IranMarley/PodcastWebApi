namespace Podcast.Application.Models
{
    public class PodcastModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string publisher { get; set; }
        public string image { get; set; }
        public string thumbnail { get; set; }
        public string listennotes_url { get; set; }
        public int total_episodes { get; set; }
        public string description { get; set; }
        public int itunes_id { get; set; }
        public string rss { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public string website { get; set; }
        public bool is_claimed { get; set; }
        public string type { get; set; }
        public List<int> genre_ids { get; set; }
        public int order { get; set; }

    }
}
