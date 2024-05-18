using Blogy.EntityLayer;

namespace Blogy.WebUI.Areas.Member.Models;

public class CommentViewModel
{
    public int CommentID { get; set; }
    public int? ParentCommentID { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public DateTime CommentDate { get; set; }
    public string CommentTime { get; set; }
    public string CommentStatus { get; set; }
    public int ArticleID { get; set; }
    public Article Article { get; set; }
    public Comment Comment { get; set; }
    public List<Comment> Comments { get; set; }
    public int TotalArticles { get; set; }
    public PageInfoModel PageInfo { get; set; }
}
