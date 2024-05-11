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

    public List<Article> GetArticlesByCategory(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Articles.Include(x => x.Writer).Include(x => x.Categories).Where(x => x.CategoryID == id).ToList();
        return values;  
    }

    public List<Article> GetArticleByFirstCategory()
    {
        using var context = new BlogyDbContext();
        var values = context.Articles.Where(x => x.CategoryID == 1).Include(x => x.Categories).ToList();
        return values;
    }

    public List<Article> GetArticleByFourthCategory()
    {
        using var context = new BlogyDbContext();
        var values = context.Articles.Where(x => x.CategoryID == 4).Include(x => x.Categories).ToList();
        return values;
    }

    public List<Article> GetArticleBySecondCategory()
    {
        using var context = new BlogyDbContext();
        var values = context.Articles.Where(x => x.CategoryID == 2).Include(x => x.Categories).ToList();
        return values;
    }

    public List<Article> GetArticleByThirdCategory()
    {
        using var context = new BlogyDbContext();
        var values = context.Articles.Where(x => x.CategoryID == 3).Include(x => x.Categories).Include(x => x.Writer).ToList();
        return values;
    }

    public void DeleteArticle(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Articles.Find(id);
        values.IsDeleted = true;
        context.Update(values);
        context.SaveChanges();
    }
}

     