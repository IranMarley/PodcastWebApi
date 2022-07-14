namespace Podcast.Domain.Entities
{
    public class PodcastFilter
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int? Genre_id { get; set; }

        public IQueryable<PodcastEntity> ApplyFilters(IQueryable<PodcastEntity> podcasts)
        {
            if (!string.IsNullOrEmpty(Title))
                podcasts = podcasts.Where(w => w.title.Contains(Title));

            if (!string.IsNullOrEmpty(Publisher))
                podcasts = podcasts.Where(w => w.publisher.Contains(Publisher));

            if (Genre_id != null)
                podcasts = podcasts.Where(w => w.genre_ids.Contains((int)Genre_id));

            return podcasts;
        }
    }
}
