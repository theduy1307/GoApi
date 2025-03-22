namespace MasterData.Infrastructure.Data;

public class PagingResultBase<T> where T : class
{
    public int PageSize { get; set; }

    public int TotalRecords { get; set; }

    public int PageCount
    {
        get
        {
            var pageCount = (double)TotalRecords / PageSize;
            return (int)Math.Ceiling(pageCount);
        }
    }

    public List<T> Items { get; set; } = [];
}