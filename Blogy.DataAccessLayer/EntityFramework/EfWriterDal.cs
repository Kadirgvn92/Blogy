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
public class EfWriterDal : GenericRepository<Writer>, IWriterDal
{
    public EfWriterDal(BlogyDbContext db) : base(db)
    {
    }

    public void ActiveWriter(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Writers.Find(id);
        values.IsActive = true;
        context.Writers.Update(values);
        context.SaveChanges();

    }

    public void DeleteWriter(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Writers.Find(id);
        values.IsDeleted = true;
        context.Writers.Update(values);
        context.SaveChanges();
    }

    public Writer GetWriter(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Writers.FirstOrDefault(x => x.AppUserID == id);
        return values;
    }

    public void PassiveWriter(int id)
    {
        using var context = new BlogyDbContext();
        var values = context.Writers.Find(id);
        values.IsActive = false;
        context.Writers.Update(values);
        context.SaveChanges();
    }
}
