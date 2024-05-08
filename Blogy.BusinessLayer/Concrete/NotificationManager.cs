using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete;
public class NotificationManager : INotificationService
{
    private readonly INotificationDal _notificationDal;

    public NotificationManager(INotificationDal notificationDal)
    {
        _notificationDal = notificationDal;
    }

    public void TDelete(int id)
    {
        _notificationDal.Delete(id);
    }

    public List<Notification> TGetAll()
    {
        return _notificationDal.GetAll();
    }

    public Notification TGetByID(int id)
    {
        return _notificationDal.GetByID(id);
    }

    public void TInsert(Notification t)
    {
       _notificationDal.Insert(t);
    }

    public void TUpdate(Notification t)
    {
       _notificationDal.Update(t);
    }
}
