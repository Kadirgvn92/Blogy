﻿using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer;

namespace Blogy.BusinessLayer.Concrete;
public class ArticleManager : IArticleService
{
    private readonly IArticleDal _articleDal;

    public ArticleManager(IArticleDal articleDal)
    {
        _articleDal = articleDal;
    }

    public List<Article> TGetArticleByFirstCategory()
    {
        return _articleDal.GetArticleByFirstCategory();
    }

    public void TDelete(int id)
    {
        _articleDal.Delete(id);
    }

    public List<Article> TGetAll()
    {
       return _articleDal.GetAll();
    }

	public List<Article> TGetAllArticles()
	{
		return _articleDal.GetAllArticles();
	}

    public Article TGetArticle(int id)
    {
        return _articleDal.GetArticle(id);
    }

    public Article TGetByID(int id)
    {
        return _articleDal.GetByID(id);
    }

    public void TInsert(Article t)
    {
        _articleDal.Insert(t);
    }

    public void TUpdate(Article t)
    {
        _articleDal.Update(t);
    }

    public List<Article> TGetArticleBySecondCategory()
    {
        return _articleDal.GetArticleBySecondCategory();
    }

    public List<Article> TGetArticleByThirdCategory()
    {
       return _articleDal.GetArticleByThirdCategory();
    }

    public List<Article> TGetArticleByFourthCategory()
    {
       return _articleDal.GetArticleByFourthCategory();
    }

    public List<Article> TGetArticlesByCategory(int id)
    {
       return _articleDal.GetArticlesByCategory(id);
    }

    public void TDeleteArticle(int id)
    {
        _articleDal.DeleteArticle(id);
    }

    public void TPassiveArticle(int id)
    {
        _articleDal.PassiveArticle(id);
    }

    public void TActiveArticle(int id)
    {
      _articleDal.ActiveArticle(id);
    }
}
