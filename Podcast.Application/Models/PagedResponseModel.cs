namespace Podcast.Application.Models
{
    public class PagedResponseModel<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public T Data { get; set; }
      
        public PagedResponseModel(T data, int pageNumber, int pageSize, int totalPages, int totalRecords)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.TotalRecords = totalRecords;
            this.Data = data;
        }
    }
}
