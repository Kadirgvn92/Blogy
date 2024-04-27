using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer;
public class Comment
{
    public int CommentID { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Content { get; set; }
    public DateTime CommentDate { get; set; }
    public string CommentStatus { get; set; }
    public int ArticleID { get; set; }
    public Article Article { get; set; }
}
