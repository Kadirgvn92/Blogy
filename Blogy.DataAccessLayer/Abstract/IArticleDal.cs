﻿using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract;
public interface IArticleDal : IGenericDal<Article>
{
    public void PassiveArticle(int id);
    public void ActiveArticle(int id);
    public void DeleteArticle(int id);
    public List<Article> GetAllArticles();
    public Article GetArticle(int id);
    public List<Article> GetArticleByFirstCategory();
    public List<Article> GetArticleBySecondCategory();
    public List<Article> GetArticleByThirdCategory();
    public List<Article> GetArticleByFourthCategory();
    public List<Article> GetArticlesByCategory(int id);
}
