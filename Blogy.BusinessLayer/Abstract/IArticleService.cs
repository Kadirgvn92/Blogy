﻿using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract;
public interface IArticleService : IGenericService<Article>
{

    public void TPassiveArticle(int id);
    public void TActiveArticle(int id);
    public void TDeleteArticle(int id);
    public List<Article> TGetAllArticles();
    public Article TGetArticle(int id);
    public List<Article> TGetArticleByFirstCategory();
    public List<Article> TGetArticleBySecondCategory();
    public List<Article> TGetArticleByThirdCategory();
    public List<Article> TGetArticleByFourthCategory();
    public List<Article> TGetArticlesByCategory(int id);
}
