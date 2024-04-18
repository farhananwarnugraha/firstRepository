namespace PhoenixWeb.ViewModels;

public class PaginatinViewModel
{
    public int? PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalData { get; set; }
    public int TotalPages { 
        get{
            return (int)Math.Ceiling((double)TotalData / PageSize);
        } 
    }
}
