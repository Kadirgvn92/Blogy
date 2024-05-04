using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete;
public class CommentManager : ICommentService
{
    private readonly ICommentDal _commentDal;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }

    public void TChangeCancel(int id)
    {
        _commentDal.ChangeCancel(id);
    }

    public void TChangeOk(int id)
    {
       _commentDal.ChangeOk(id);
    }

    public void TDelete(int id)
    {
        _commentDal.Delete(id);
    }

    public List<Comment> TGetAll()
    {
       return _commentDal.GetAll();
    }

    public Comment TGetByID(int id)
    {
       return _commentDal.GetByID(id);
    }

    public List<Comment> TGetCommentsWithArticleId(int id)
    {
        return _commentDal.GetCommentsWithArticleId(id);
    }

    public void TInsert(Comment t)
    {
        _commentDal.Insert(t);
    }

    public void TUpdate(Comment t)
    {
        _commentDal.Update(t);
    }
}
