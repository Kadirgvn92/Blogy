using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultFirstPartial : ViewComponent
{
    private readonly IArticleService _articleService;

    public _UIDefaultFirstPartial(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public IViewComponentResult Invoke()
	{
        var values = _articleService.TGetAllArticles();
        return View(values);
	}
}
