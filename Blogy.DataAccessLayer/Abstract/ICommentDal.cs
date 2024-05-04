using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract;
public interface ICommentDal : IGenericDal<Comment>
{
    public List<Comment> GetCommentsWithArticleId(int id);
    public void ChangeOk(int id);
    public void ChangeCancel(int id);

}
