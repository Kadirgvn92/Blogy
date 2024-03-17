using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete;
public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public List<Category> TGetCategories()
    {
        return _categoryDal.GetCategories();
    }

    public void TDelete(int id)
    {
        _categoryDal.Delete(id);
    }

    public List<Category> TGetAll()
    {
        return _categoryDal.GetAll();
    }

    public Category TGetByID(int id)
    {
        return _categoryDal.GetByID(id);
    }

    public void TInsert(Category t)
    {
       _categoryDal.Insert(t);
    }

    public void TUpdate(Category t)
    {
        _categoryDal.Update(t);
    }
}
