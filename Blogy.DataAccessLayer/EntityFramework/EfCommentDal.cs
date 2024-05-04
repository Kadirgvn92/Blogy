using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework;
public class EfCommentDal : GenericRepository<Comment>, ICommentDal
{
    public EfCommentDal(BlogyDbContext db) : base(db)
    {
    }

    public void ChangeCancel(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Comments.Find(id);
        if(values != null)
        {
            values.CommentStatus = "İptal Edildi";
            context.Comments.Update(values);
            context.SaveChanges();
        }
    }

    public void ChangeOk(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Comments.Find(id);
        if (values != null)
        {
            values.CommentStatus = "Onaylandı";
            context.Comments.Update(values);
            context.SaveChanges();
        }
    }

    public List<Comment> GetCommentsWithArticleId(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Comments.Where(x => x.ArticleID  == id).ToList();  
        return values;
    }
}
