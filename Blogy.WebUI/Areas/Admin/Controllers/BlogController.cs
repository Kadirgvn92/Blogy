using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Container;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class BlogController : Controller
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
    public BlogController(IArticleService articleService, UserManager<AppUser> userManager, IWriterService writerService, ICategoryService categoryService)
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

    public IActionResult CreateBlog()
    {
        List<SelectListItem> Category = (from x in _categoryService.TGetAll()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
        ViewBag.c = Category;
        List<SelectListItem> Writer = (from x in _writerService.TGetAll()
                                       select new SelectListItem
                                       {
                                           Text = x.Name,
                                           Value = x.WriterID.ToString()
                                       }).ToList();
        ViewBag.w = Writer;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogViewModel model)
    {
        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(model.Image.FileName);
        var imagename = GenerateName() + extension;
        var savelocation = resource + "/wwwroot/articleImages/" + imagename;
        var stream = new FileStream(savelocation, FileMode.Create);
        await model.Image.CopyToAsync(stream);
        model.CoverImageUrl = imagename;


        Article article = new()
        {
            Title = model.Title,
            CategoryID = model.CategoryID,
            WriterID = model.WriterID,
            FirstSection = model.FirstSection,
            SecondSection = model.SecondSection,
            ThirdSection = model.ThirdSection,
            FourthSection = model.FourthSection,
            CoverImageUrl = model.CoverImageUrl,
            Description = model.Description,
            CreatedDate = DateTime.Now,
        };

        _articleService.TInsert(article);
        return RedirectToAction("Index", "Blog", new { area = "Admin" });
    }
    public IActionResult DeleteArticle(int id)
    {
        _articleService.TDelete(id);
        return View();
    }
    
}
