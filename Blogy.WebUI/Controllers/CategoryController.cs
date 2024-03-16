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

	public IActionResult Index()
    {
		var values = _articleService.TGetAllArticles();
        return View(values);
    }
}
