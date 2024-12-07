namespace Rigor.Application.Helpers
{
    public class PaginatedList<T>
    {
        public object Data { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(object items, int totalCount, int pageNumber, int pageSize, int totalPages)
        {
            Data = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
        }
        public PaginatedList()
        {

        }
    }

}
