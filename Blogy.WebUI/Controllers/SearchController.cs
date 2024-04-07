using Blogy.BusinessLayer.Abstract;
using Blogy.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;

namespace Blogy.WebUI.Controllers;
public class SearchController : Controller
{
    private readonly IArticleService _articleService;

    public SearchController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public IActionResult Index(string searchString,int page = 1)
    {
        ViewData["CurrentFilter"] = searchString;
        ViewBag.SearchString = searchString;

        var valueSeach = from x in _articleService.TGetAllArticles() select x;
        if (!string.IsNullOrEmpty(searchString))
        {
            searchString = searchString.ToLower();
            valueSeach = valueSeach.Where(y => y.Title.ToLower().Contains(searchString));
        }

        const int pageSize = 3;
        var model = new SearchViewModel
        {
            PageInfo = new PageInfoModel()
            {
                TotalItems = valueSeach.Count(),
                CurrentPage = page,
                ItemsPerPage = pageSize,
            },
            Articles = valueSeach.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            TotalArticles = valueSeach.Count(),
            search = searchString
        };
        return View(model);
    }
}
