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

        // Bu haftanın başlangıç ve bitiş tarihlerini bulun
        DateTime today = DateTime.Today;
        DateTime monday = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
        DateTime sunday = monday.AddDays(6);

        DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
        DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

        var article1 = _articleService.TGetAll().Count();
        ViewBag.Article1 = article1;    

        var article2 = _categoryService.TGetAll().Count();
        ViewBag.Article2 = article2;

        var comment = _commentService.TGetAll().Count();
        ViewBag.Comment1 = comment;

        var web = _articleService.TGetAll().Where(x => x.CategoryID == 1).Count();
        ViewBag.Web = web;

        var mobil = _articleService.TGetAll().Where(x => x.CategoryID == 2).Count();
        ViewBag.Mobil = mobil;

        var yapay = _articleService.TGetAll().Where(x => x.CategoryID == 3).Count();
        ViewBag.Yapay = yapay;

        var devops = _articleService.TGetAll().Where(x => x.CategoryID == 4).Count();
        ViewBag.Devops = devops;

        var bugun = _articleService.TGetAll().Where(x => x.CreatedDate == DateTime.Now).Count();
        ViewBag.Bugun = bugun;

        var hafta = _articleService.TGetAll().Where(x => x.CreatedDate >= monday && x.CreatedDate <= sunday).Count();
        ViewBag.Hafta = hafta;

        // Bu ayın başlangıç ve bitiş tarihlerini kullanarak makaleleri filtreleyin
        var aylık = _articleService.TGetAll().Where(x => x.CreatedDate >= firstDayOfMonth && x.CreatedDate <= lastDayOfMonth).Count();
        ViewBag.Aylik = aylık;

        return View();
    }
}
