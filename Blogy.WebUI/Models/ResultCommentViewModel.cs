using Blogy.EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace Blogy.WebUI.Models;

public class ResultCommentViewModel
{
    public int ArticleID { get; set; }
    public Article Article { get; set; }
    public int ArticleCount { get; set; }
    public List<Comment> Comment { get; set; }
}
