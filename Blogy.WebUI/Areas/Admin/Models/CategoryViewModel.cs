using Blogy.EntityLayer;

namespace Blogy.WebUI.Areas.Admin.Models;

public class CategoryViewModel
{
	public int CategoryID { get; set; }
	public string? CategoryName { get; set; }
	public string? CategoryImageUrl { get; set; }
	public Category Category { get; set; }
	public List<Category> Categories { get; set; }
	public int TotalArticles { get; set; }
	public PageInfoModel PageInfo { get; set; }


}
