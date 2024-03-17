using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultSecondPartial : ViewComponent
{
	private readonly IArticleService _articleService;
	private readonly ICategoryService _categoryService;

	public _UIDefaultSecondPartial(IArticleService articleService, ICategoryService categoryService)
	{
		_articleService = articleService;
		_categoryService = categoryService;
	}

	public IViewComponentResult Invoke()
	{
		var values = _articleService.TGetArticleByFirstCategory();
		var cat = values.FirstOrDefault(x => x.CategoryID == 1);
		ViewBag.Category = cat.Categories.CategoryName;	
		return View(values);
	}
}
