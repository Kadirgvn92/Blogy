using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.EntityLayer;
using Blogy.WebUI.Image;
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
        
        string randomImage = ImageService.GetRandomImage();

        Comment comment = new Comment()
        {
            Content = model.Content,
            CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
            CommentTime = DateTime.Now.ToString("HH:mm"),
            CommentStatus = "Onay Bekliyor",
            ArticleID = model.ArticleID,
            FullName = model.FullName,
            Email = model.Email,
            Image = randomImage

        };
        _commentService.TInsert(comment);
        return RedirectToAction("Index", "Default");
    }

    [HttpPost]
    public IActionResult ReplyToComment(ReplyViewModel model)
    {
        if (ModelState.IsValid)
        {
            var newComment = new Comment
            {
                FullName = model.FullName,
                Email = model.Email,
                Content = model.Content,
                CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                CommentStatus = "Onay Bekliyor", // veya başka bir varsayılan değer
                ArticleID = model.ArticleID, // Yanıtlanan yorumun hangi makaleye ait olduğunu al
                ParentCommentID = model.ParentCommentID // Yanıtlanan yorumun ID'sini al
            };

            _commentService.TInsert(newComment);

            return RedirectToAction("Index", "Home");
        }

        // Eğer model doğrulaması başarısız olursa, aynı view'i tekrar göster
        return View(model);
    }

}
