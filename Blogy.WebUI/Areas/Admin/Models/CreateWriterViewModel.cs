using Blogy.EntityLayer;

namespace Blogy.WebUI.Areas.Admin.Models;

public class CreateWriterViewModel
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public IFormFile Image { get; set; }
}
