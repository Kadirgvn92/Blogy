using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers;
public class CategoryController : Controller
{
    private readonly IArticleService _articleService;

	public CategoryController(IArticleService articleService)
	{
		_articleService = articleService;
	}

	public IActionResult Index(int id)
    {
		var values = _articleService.TGetArticleByCategory(id);
		var cat = values.FirstOrDefault(x => x.CategoryID == id);
		ViewBag.Category = cat.Categories.CategoryName;
        return View(values);
    }
}
