using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Repository;
public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly BlogyDbContext _db;

    public GenericRepository(BlogyDbContext db)
    {
        _db = db;
    }

    public void Delete(int id)
    {

        var values = _db.Set<T>().Find(id);
        if(values != null)
        {
            _db.Set<T>().Remove(values);
            _db.SaveChanges();
        }
    }

    public List<T> GetAll()
    {
        var values = _db.Set<T>().ToList();
        return values;
    }

    public T GetByID(int id)
    {
        var values = _db.Set<T>().Find(id);
        return values;
    }

    public void Insert(T t)
    {
        _db.Set<T>().Add(t);
        _db.SaveChanges();
    }

    public void Update(T t)
    {
       _db.Set<T>().Update(t);
        _db.SaveChanges();
    }
}
