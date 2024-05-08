using Blogy.BusinessLayer.Abstract;
using Blogy.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PageInfoModel = Blogy.WebUI.Areas.Member.Models.PageInfoModel;

namespace Blogy.WebUI.Controllers;
[AllowAnonymous]
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
		const int pageSize = 5;

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
