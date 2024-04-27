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

    public List<Comment> GetCommentsWithArticleId(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Comments.Where(x => x.ArticleID  == id).ToList();  
        return values;
    }
}
