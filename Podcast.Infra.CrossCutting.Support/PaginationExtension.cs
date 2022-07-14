namespace Podcast.Infra.CrossCutting.Support
{
    public static class PaginationExtension
    {
        public static IEnumerable<T> ToPaginated<T>(this IQueryable<T> list, Pagination pagination)
        {
            return list.Skip(pagination.Size * (pagination.Page - 1)).Take(pagination.Size).ToList();
        }
    }
}
