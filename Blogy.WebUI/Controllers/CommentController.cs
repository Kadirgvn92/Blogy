using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.EntityLayer;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers;
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    [HttpGet]
    public PartialViewResult AddComment(int Articleid)
    {
        ViewBag.i = Articleid;
        return PartialView();
    }
    [HttpPost]
    public IActionResult AddComment(AddCommentViewModel model)
    {
        Comment comment = new Comment()
        {
            Content = model.Content,
            CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
            CommentStatus = "Onay Bekliyor",
            ArticleID = model.ArticleID,
            FullName = model.FullName,
            Email = model.Email,
        };
        _commentService.TInsert(comment);
        return RedirectToAction("Index", "Default");
    }
}
