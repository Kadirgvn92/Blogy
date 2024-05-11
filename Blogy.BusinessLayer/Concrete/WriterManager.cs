using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete;
public class WriterManager : IWriterService
{
    private readonly IWriterDal _writerDal;

    public WriterManager(IWriterDal writerDal)
    {
        _writerDal = writerDal;
    }

    public void TActiveWriter(int id)
    {
        _writerDal.ActiveWriter(id);
    }

    public void TDeleteWriter(int id)
    {
       _writerDal.DeleteWriter(id);
    }

    public void TPassiveWriter(int id)
    {
        _writerDal.PassiveWriter(id);
    }

    public void TDelete(int id)
    {
        _writerDal.Delete(id);
    }

    public List<Writer> TGetAll()
    {
       return _writerDal.GetAll();
    }

    public Writer TGetByID(int id)
    {
        return _writerDal.GetByID(id);
    }

    public void TInsert(Writer t)
    {
       _writerDal.Insert(t);
    }

    public void TUpdate(Writer t)
    {
        _writerDal.Update(t);
    }
}
