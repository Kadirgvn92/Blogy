using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.ViewComponents;

public class _AdminDashboardAllComment : ViewComponent
{
    private readonly ICommentService _commentService;

    public _AdminDashboardAllComment(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public IViewComponentResult Invoke()
    {
        var values = _commentService.TGetAll();
        return View(values);
    }
}
