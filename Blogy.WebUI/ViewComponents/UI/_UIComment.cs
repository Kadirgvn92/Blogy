using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Blogy.WebUI.Areas.Admin.Models;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;

namespace Blogy.WebUI.ViewComponents.UI;

public class _UIComment : ViewComponent
{
    private readonly ICommentService _commentService;

    public _UIComment(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public IViewComponentResult Invoke(int id)
    {
        var model = new ResultCommentViewModel
        {
           Comment = _commentService.TGetCommentsWithArticleId(id),
           ArticleCount = _commentService.TGetCommentsWithArticleId(id).Count(),
           ArticleID = id
        };
        return View(model);
    }
}
