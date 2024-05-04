using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract;
public interface ICommentService : IGenericService<Comment>
{
    public List<Comment> TGetCommentsWithArticleId(int id);

    public void TChangeOk(int id);
    public void TChangeCancel(int id);

    public List<Comment> TGetWaitingComments();
    public List<Comment> TGetAcceptedComments();
    public List<Comment> TGetCanceledComments();
}
