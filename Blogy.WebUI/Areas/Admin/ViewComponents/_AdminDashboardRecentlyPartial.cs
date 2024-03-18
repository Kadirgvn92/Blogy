using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.ViewComponents;

public class _AdminDashboardRecentlyPartial : ViewComponent
{
    private readonly IArticleService _articleService;

    public _AdminDashboardRecentlyPartial(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _articleService.TGetAllArticles();
        return View(values);  
    }
}
