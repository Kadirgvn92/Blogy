using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract;
public interface IGenericService<T> where T : class
{
    void TInsert(T t);
    void TUpdate(T t);
    void TDelete(int id);
    T TGetByID(int id);
    List<T> TGetAll();
}
