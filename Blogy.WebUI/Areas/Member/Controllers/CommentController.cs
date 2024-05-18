using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogy.WebUI.Areas.Member.Controllers;
[Area("Member")]
[Route("Member/[controller]/[action]/{id?}")]

public class CommentController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IWriterService _writerService;
    private readonly IArticleService _articleService;
    private readonly ICommentService _commentService;

    public CommentController(UserManager<AppUser> userManager, IWriterService writerService, IArticleService articleService, ICommentService commentService)
    {
        _userManager = userManager;
        _writerService = writerService;
        _articleService = articleService;
        _commentService = commentService;
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var writer = _writerService.TGetWriter(user.Id);
        var articles = _articleService.TGetAllArticles().Where(x => x.WriterID == writer.WriterID);
        var comments = _commentService.TGetCommentsWithArticles();

        var articleIds = articles.Select(a => a.ArticleID).ToList();
        var matchingComments = comments
       .Where(c => articleIds.Contains(c.ArticleID))
       .ToList();

        const int pageSize = 10;

        var model = new CommentViewModel
        {
            PageInfo = new PageInfoModel()
            {
                TotalItems = matchingComments.Count(),
                CurrentPage = page,
                ItemsPerPage = pageSize,
            },
            Comments = matchingComments.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            TotalArticles = matchingComments.Count(),
        };
        return View(model);
    }
}
