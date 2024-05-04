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
        return RedirectToAction("Index");
    }
    public IActionResult ChangeCancel(int id)
    {
        _commentService.TChangeCancel(id);
        return RedirectToAction("Index");
    }

    public IActionResult AcceptedCommentList()
    {
        
        return View();
    }
    public IActionResult WaitingCommentList()
    {
        return View();
    }
    public IActionResult CanceledCommentList()
    {
        return View();
    }
}
