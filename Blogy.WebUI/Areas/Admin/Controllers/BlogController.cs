using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class BlogController : Controller
{
    private readonly IArticleService _articleService;
    private readonly UserManager<AppUser> _userManager;

    public BlogController(IArticleService articleService, UserManager<AppUser> userManager)
    {
        _articleService = articleService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        const int pageSize = 10;
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var model = new ArticleViewModel
        {
            PageInfo = new PageInfoModel()
            {
                TotalItems = _articleService.TGetAllArticles().Count(),
                CurrentPage = page,
                ItemsPerPage = pageSize,
            },
            Articles = _articleService.TGetAllArticles().OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            TotalArticles = _articleService.TGetAllArticles().Count(),
        };
        return View(model);
    }
}
