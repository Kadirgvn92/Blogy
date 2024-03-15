using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer;
public class Article
{
    public int ArticleID { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public string? CoverImageUrl { get; set; }
    public int CategoryID { get; set; }
    public Category Category { get; set; }
    public int WriterID { get; set; }
    public Writer Writer { get; set; }
    public List<Comment> Comments { get; set; }
}
