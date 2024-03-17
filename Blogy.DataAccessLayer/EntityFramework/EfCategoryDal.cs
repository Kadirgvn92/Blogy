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
public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
{
    public EfCategoryDal(BlogyDbContext db) : base(db)
    {
    }

    public List<Category> GetCategories()
    {
        using var context = new BlogyDbContext();
        var values = context.Categories.Include(x => x.Articles).ToList();
        return  values;
    }
}
