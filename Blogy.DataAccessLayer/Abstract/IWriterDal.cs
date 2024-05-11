using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract;
public interface IWriterDal : IGenericDal<Writer>
{
    public void ActiveWriter(int id);
    public void PassiveWriter(int id);
    public void DeleteWriter(int id);
    public Writer GetWriter(int id);
}
