using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.ViewComponents;

public class _AdminDashboardWaitingCommentPartial : ViewComponent
{
    private readonly ICommentService _commentService;

    public _AdminDashboardWaitingCommentPartial(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _commentService.TGetWaitingComments();
        return View(values);
    }
}
