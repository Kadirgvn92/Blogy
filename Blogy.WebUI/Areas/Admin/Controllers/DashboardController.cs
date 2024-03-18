using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class DashboardController : Controller
{
    private readonly IArticleService _articleService;
    private readonly ICategoryService _categoryService;
    private readonly ICommentService _commentService;

    public DashboardController(IArticleService articleService, ICategoryService categoryService, ICommentService commentService)
    {
        _articleService = articleService;
        _categoryService = categoryService;
        _commentService = commentService;
    }

    public IActionResult Index()
    {
        var article1 = _articleService.TGetAll().Count();
        ViewBag.Article1 = article1;    

        var article2 = _categoryService.TGetAll().Count();
        ViewBag.Article2 = article2;

        var comment = _commentService.TGetAll().Count();
        ViewBag.Comment1 = comment;    

        return View();
    }
}
