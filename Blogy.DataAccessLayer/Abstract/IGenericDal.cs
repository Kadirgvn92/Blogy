using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract;
public interface IGenericDal<T> where T : class
{
    void Insert(T t);
    void Update(T t);
    void Delete(int id);
    T GetByID(int id);
    List<T> GetAll();
}
