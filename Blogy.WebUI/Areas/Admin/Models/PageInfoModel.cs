namespace Blogy.WebUI.Areas.Admin.Models;

public class PageInfoModel
{
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int CurrentPage { get; set; }
    public string CurrentCategory { get; set; }

    public int TotalPages()
    {
        return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
