using Blogy.EntityLayer;

namespace Blogy.WebUI.Models;

public class AddCommentViewModel
{
    public int CommentID { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Content { get; set; }
    public DateTime CommentDate { get; set; }
    public string CommentStatus { get; set; }
    public int ArticleID { get; set; }
}
