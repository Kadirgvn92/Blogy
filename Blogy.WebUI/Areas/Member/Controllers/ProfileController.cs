using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Member.Controllers;

[Area("Member")]
[Route("Member/[controller]/[action]/{id?}")]
public class ProfileController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IWriterService _writerService;
    private readonly IArticleService _articleService;
    private readonly ICommentService _commentService;

    public ProfileController(UserManager<AppUser> userManager, IWriterService writerService, IArticleService articleService, ICommentService commentService)
    {
        _userManager = userManager;
        _writerService = writerService;
        _articleService = articleService;
        _commentService = commentService;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var writer = _writerService.TGetWriter(user.Id);
        var count = _articleService.TGetAllArticles().Where(x => x.WriterID == writer.WriterID).Count();
        var articles = _articleService.TGetAllArticles().Where(x => x.WriterID == writer.WriterID);
        var comments = _commentService.TGetAll().Where(x => x.CommentStatus == "Onaylandı");

        var articleIds = articles.Select(a => a.ArticleID).ToList();

        // Comments tablosundaki articleID'leri makalelerin articleID'leri ile karşılaştırarak eşleşmeleri bulun
        var matchingCommentsCount = comments.Count(c => articleIds.Contains(c.ArticleID));
        
        ViewBag.Comments = matchingCommentsCount;
        ViewBag.Count = count; 
        ViewBag.Writer = writer.Name;
        ViewBag.Image = writer.ImageUrl;



        return View();
    }
}
