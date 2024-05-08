using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Migrations;
using Blogy.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework;
public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
{
    public EfNotificationDal(BlogyDbContext db) : base(db)
    {
    }
}
