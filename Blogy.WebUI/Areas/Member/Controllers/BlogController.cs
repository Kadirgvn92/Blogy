using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PageInfoModel = Blogy.WebUI.Areas.Member.Models.PageInfoModel;

namespace Blogy.WebUI.Areas.Member.Controllers;

[Area("Member")]
[Route("Member/[controller]/[action]/{id?}")]
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
    [HttpGet]
    public IActionResult UpdateArticle(int id)
    {
        var values = _articleService.TGetByID(id);
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
        if (values != null)
        {
            var model = new UpdateArticleViewModel
            {
                Title = values.Title,
                CategoryID = values.CategoryID,
                ArticleID = values.ArticleID,
                Description = values.Description,
                FirstSection = values.FirstSection,
                SecondSection = values.SecondSection,
                ThirdSection = values.ThirdSection,
                FourthSection = values.FourthSection,
                CoverImageUrl = values.CoverImageUrl,
                WriterID = values.WriterID,
            };

            return View(model);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateArticle(UpdateArticleViewModel model)
    {
        var values = _articleService.TGetByID(model.ArticleID);

        if(model.Image !=  null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(model.Image.FileName);
            var imagename = GenerateName() + extension;
            var savelocation = resource + "/wwwroot/articleImages/" + imagename;
            var stream = new FileStream(savelocation, FileMode.Create);
            await model.Image.CopyToAsync(stream);
            model.CoverImageUrl = imagename;
        }else
        {
            model.CoverImageUrl = values.CoverImageUrl;
        }
       

        if (values != null)
        {
            values.WriterID = model.WriterID;
            values.Title = model.Title;
            values.CategoryID = model.CategoryID;
            values.Description = model.Description;
            values.FirstSection = model.FirstSection;
            values.SecondSection = model.SecondSection;
            values.ThirdSection = model.ThirdSection;
            values.FourthSection = model.FourthSection;
            values.CoverImageUrl = model.CoverImageUrl;

            _articleService.TUpdate(values);
            return RedirectToAction("Index");
        }
        return View();
    }
}
