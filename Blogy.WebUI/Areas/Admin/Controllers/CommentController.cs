using Blogy.BusinessLayer.Abstract;
using Blogy.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    public IActionResult Index()
    {
        var comments = _commentService.TGetAll();
        return View(comments);
    }
    [HttpGet]
    public IActionResult GetComment()
    {
        // Comment nesnelerini al
        var comments = _commentService.TGetAll();
        // Comment nesnelerini JSON formatına dönüştür
        var jsonComments = JsonConvert.SerializeObject(comments);
        // JSON formatındaki Comment nesnelerini View'e gönder
        return Content(jsonComments, "application/json");
    }
    
    public IActionResult ChangeOk(int id)
    {
        _commentService.TChangeOk(id);
        return RedirectToAction("WaitingCommentList","Comment", new { area = "Admin" });
    }
    public IActionResult ChangeCancel(int id)
    {
        _commentService.TChangeCancel(id);
        return RedirectToAction("CanceledCommentList", "Comment", new { area = "Admin" });
    }

    public IActionResult AcceptedCommentList()
    {
        var comments = _commentService.TGetAcceptedComments();
        return View(comments);
    }
    [HttpGet]
    public IActionResult GetAcceptedComment()
    {
        // Comment nesnelerini al
        var comments = _commentService.TGetAcceptedComments();
        // Comment nesnelerini JSON formatına dönüştür
        var jsonComments = JsonConvert.SerializeObject(comments);
        // JSON formatındaki Comment nesnelerini View'e gönder
        return Content(jsonComments, "application/json");
    }
    public IActionResult WaitingCommentList()
    {
        var comments = _commentService.TGetWaitingComments();
        return View(comments);
    }
    [HttpGet]
    public IActionResult GetWaitingComment()
    {
        // Comment nesnelerini al
        var comments = _commentService.TGetWaitingComments();
        // Comment nesnelerini JSON formatına dönüştür
        var jsonComments = JsonConvert.SerializeObject(comments);
        // JSON formatındaki Comment nesnelerini View'e gönder
        return Content(jsonComments, "application/json");
    }
    public IActionResult CanceledCommentList()
    {
        var comments = _commentService.TGetCanceledComments();
        return View(comments);
    }
    [HttpGet]
    public IActionResult GetCanceledComment()
    {
        // Comment nesnelerini al
        var comments = _commentService.TGetCanceledComments();
        // Comment nesnelerini JSON formatına dönüştür
        var jsonComments = JsonConvert.SerializeObject(comments);
        // JSON formatındaki Comment nesnelerini View'e gönder
        return Content(jsonComments, "application/json");
    }
}
