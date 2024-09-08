namespace CustomersWebApp.Domain.Pagination;

public class PaginatedResult<T> 
{
    public List<T> Data { get; set; } = new List<T>();
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }

}
