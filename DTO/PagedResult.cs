
namespace LMS.DTO
{
    public class PagedResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; } = 0;    
        public int TotalPages { get; set; }

        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

    }
}
