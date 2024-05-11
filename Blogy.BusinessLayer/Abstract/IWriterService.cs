using Blogy.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract;
public interface IWriterService : IGenericService<Writer>
{

    public void TActiveWriter(int id);
    public void TPassiveWriter(int id);
    public void TDeleteWriter(int id);
}
