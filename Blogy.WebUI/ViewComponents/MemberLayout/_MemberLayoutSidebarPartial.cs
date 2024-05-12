using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.MemberLayout;

public class _MemberLayoutSidebarPartial : ViewComponent
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IWriterService _writerService;
    private readonly IArticleService _articleService;

    public _MemberLayoutSidebarPartial(UserManager<AppUser> userManager, IWriterService writerService, IArticleService articleService)
    {
        _userManager = userManager;
        _writerService = writerService;
        _articleService = articleService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var writer = _writerService.TGetWriter(user.Id);
        var articles = _articleService.TGetAllArticles().Where(x => x.WriterID == writer.WriterID).Count();
        ViewBag.Articles = articles;
        ViewBag.Writer = writer.Name;
        return View();
    }
}
