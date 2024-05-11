
using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Articley.WebUI.Areas.Member.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class ArticleController : Controller
{
    private readonly IArticleService _articleService;
    private readonly UserManager<AppUser> _userManager;

    public string GenerateName()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        Random random = new Random();
        char[] stringChars = new char[6];

        for (int i = 0; i < 6; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }
    public ArticleController(IArticleService articleService, UserManager<AppUser> userManager)
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
            Articles = _articleService.TGetAllArticles().Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            TotalArticles = _articleService.TGetAllArticles().Count(),
        };
        return View(model);
    }
    public IActionResult DeleteArticle(int id)
    {
        _articleService.TDeleteArticle(id);
        return RedirectToAction("Index");
    }
    public IActionResult PassiveArticle(int id)
    {
        _articleService.TPassiveArticle(id);
        return RedirectToAction("Index");
    }
    public IActionResult ActiveArticle(int id)
    {
        _articleService.TActiveArticle(id);
        return RedirectToAction("Index");
    }
}
