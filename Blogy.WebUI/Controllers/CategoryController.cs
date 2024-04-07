using Blogy.BusinessLayer.Abstract;
using Blogy.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogy.WebUI.Controllers;
public class CategoryController : Controller
{
	private readonly IArticleService _articleService;

	public CategoryController(IArticleService articleService)
	{
		_articleService = articleService;
	}

	public IActionResult Index(int id, int page = 1)
	{
		var values = _articleService.TGetArticlesByCategory(id);
		var cat = values.FirstOrDefault(x => x.CategoryID == id);
		
		ViewBag.Category = cat.Categories.CategoryName;
		const int pageSize = 3;

		var model = new ArticleViewModel
		{
			PageInfo = new PageInfoModel()
			{
				TotalItems = _articleService.TGetArticlesByCategory(id).Count(),
				CurrentPage = page,
				ItemsPerPage = pageSize,
			},
			Articles = _articleService.TGetArticlesByCategory(id).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
			TotalArticles = _articleService.TGetArticlesByCategory(id).Count(),
			CategoryID = id
		};
		return View(model);
	}
}
