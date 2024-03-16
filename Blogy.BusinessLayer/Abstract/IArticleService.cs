using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract;
public interface IArticleService : IGenericService<Article>
{
	public List<Article> TGetAllArticles();
    public Article TGetArticle(int id);
}
