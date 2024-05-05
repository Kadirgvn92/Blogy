using Blogy.EntityLayer;

namespace Blogy.WebUI.Areas.Admin.Models;

public class WriterViewModel
{
    public int WriterID { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int BlogCount { get; set; }
    public List<Article> Articles { get; set; }
}
