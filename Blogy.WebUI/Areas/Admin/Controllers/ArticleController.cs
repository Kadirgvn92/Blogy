
using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Articley.WebUI.Areas.Member.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class ArticleController : Controller
{
    private readonly IArticleService _articleService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IWriterService _writerService;
    private readonly ICategoryService _categoryService;

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
    public ArticleController(IArticleService articleService, UserManager<AppUser> userManager, IWriterService writerService, ICategoryService categoryService)
    {
        _articleService = articleService;
        _userManager = userManager;
        _writerService = writerService;
        _categoryService = categoryService;
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
    public IActionResult DeleteArticle(int id)
    {
        _articleService.TDeleteArticle(id);
        return View();
    }
}
