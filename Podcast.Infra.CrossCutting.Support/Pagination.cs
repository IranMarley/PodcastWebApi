namespace Podcast.Infra.CrossCutting.Support
{
    public class Pagination
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public int SkipPage(Pagination entity)
        {
            return entity.Page > 1
                ? (entity.Page - 1) * entity.Size : 0;
        }

        public Pagination CalcPagination(Pagination entity, int count)
        {
            return new Pagination
            {
                Page = entity.Page != 0 ? entity.Page : 1,
                Size = entity.Size,
                TotalPages = (int)Math.Ceiling(count / Convert.ToDouble(entity.Size)),
                TotalRecords = count
            };
        }
    }
}
