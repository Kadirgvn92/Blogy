using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework;
public class EfArticleDal : GenericRepository<Article>, IArticleDal
{
    public EfArticleDal(BlogyDbContext db) : base(db)
    {
       
    }

    public List<Article> GetAllArticles()
    {
        using var context = new BlogyDbContext();
        var values = context.Articles.Include(x => x.Categories).Include(x => x.Writer).ToList();
        return values;  
    }

    public Article GetArticle(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Articles.Include(x => x.Writer).Include(x => x.Categories).FirstOrDefault(x => x.ArticleID == id);
        return values;
    }
}

     