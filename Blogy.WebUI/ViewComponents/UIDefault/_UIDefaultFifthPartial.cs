using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultFifthPartial : ViewComponent
{
	private readonly IArticleService _articleService;

    public _UIDefaultFifthPartial(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public IViewComponentResult Invoke()
	{
        var values = _articleService.TGetArticleByThirdCategory();
		var cat = values.FirstOrDefault(x => x.CategoryID == 3);
		ViewBag.Category = cat.Categories.CategoryName;
		ViewBag.CategoryID = cat.Categories.CategoryID;
		return View(values);
	}
}
